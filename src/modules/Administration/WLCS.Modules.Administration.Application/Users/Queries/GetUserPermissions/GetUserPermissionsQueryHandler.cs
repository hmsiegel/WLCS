// <copyright file="GetUserPermissionsQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUserPermissions;

/// <summary>
/// The handler for the GetUserPermissionsQuery.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetUserPermissionsQueryHandler"/> class.
/// </remarks>
/// <param name="dbConnectionFactory">An instance of the <see cref="IDbConnectionFactory"/>".</param>
internal sealed class GetUserPermissionsQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IQueryHandler<GetUserPermissionsQuery, PermissionResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  /// <inheritdoc/>
  public async Task<Result<PermissionResponse>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
  {
    using DbConnection connection = await _dbConnectionFactory.OpenConnectionAsync(cancellationToken)
      .ConfigureAwait(false);

    const string sql =
      $"""
      SELECT DISTINCT
        u.id as {nameof(UserPermission.UserId)},
        rp.permission_code AS {nameof(UserPermission.Permission)}
      FROM administration.users u
      JOIN administration.user_roles ur ON ur.user_id = u.id
      JOIN administration.role_permissions rp ON rp.role_name = ur.role_name
      WHERE u.identity_id = @IdentityId
      """;

    var permissions = (await connection.QueryAsync<UserPermission>(sql, request).ConfigureAwait(false)).AsList();

    if (permissions.Count == 0)
    {
      return Result.Failure<PermissionResponse>(UserErrors.NotFound(request.IdentityId));
    }

    return new PermissionResponse(
      permissions[0].UserId,
      permissions.Select(p => p.Permission).ToHashSet());
  }
}
