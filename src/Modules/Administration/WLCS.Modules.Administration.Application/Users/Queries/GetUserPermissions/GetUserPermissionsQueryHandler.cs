// <copyright file="GetUserPermissionsQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUserPermissions;

internal sealed class GetUserPermissionsQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IQueryHandler<GetUserPermissionsQuery, PermissionsResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<Result<PermissionsResponse>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    const string sql =
      $"""
      SELECT DISTINCT
        u.Id AS {nameof(UserPermission.UserId)},
        rp.permission_code AS {nameof(UserPermission.Permission)}
      FROM administration.users u
      JOIN administration.user_roles ur ON ur.user_id = u.id
      JOIN administration.role_permissions rp ON rp.role_name = ur.roles_name
      WHERE u.identity_id = @IdentityId
      """;

    var permissions = (await connection.QueryAsync<UserPermission>(sql, request)).ToList();

    if (permissions.Count == 0)
    {
      return Result.Failure<PermissionsResponse>(UserErrors.NotFoud(request.IdentityId));
    }

    return new PermissionsResponse(permissions[0].UserId, permissions.Select(p => p.Permission).ToHashSet());
  }

  internal sealed class UserPermission
  {
    internal Guid UserId { get; init; }

    internal string Permission { get; init; } = string.Empty;
  }
}
