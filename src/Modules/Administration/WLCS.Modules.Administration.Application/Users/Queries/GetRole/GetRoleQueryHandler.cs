// <copyright file="GetRoleQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Administration.Application.Users.Queries.ListRoles;

namespace WLCS.Modules.Administration.Application.Users.Queries.GetRole;

internal sealed class GetRoleQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IQueryHandler<GetRoleQuery, RoleResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<Result<RoleResponse>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    const string sql =
      $@"
      SELECT DISTINCT
        role_name AS {nameof(RoleResponse.Name)}
      FROM administration.roles
      WHERE role_name = @Name
      ";

    var role = await connection.QueryFirstOrDefaultAsync<RoleResponse>(sql, new { request.Name });

    if (role is null)
    {
      return Result.Failure<RoleResponse>(UserErrors.RoleNotFound(request.Name));
    }

    return role;
  }
}
