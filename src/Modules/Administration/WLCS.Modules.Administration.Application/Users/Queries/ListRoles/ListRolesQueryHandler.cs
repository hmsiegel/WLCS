// <copyright file="ListRolesQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.ListRoles;

internal sealed class ListRolesQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IQueryHandler<ListRolesQuery, List<RoleResponse>>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<Result<List<RoleResponse>>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    const string sql =
      $@"
      SELECT DISTINCT
        role_name AS {nameof(RoleResponse.Name)}
      FROM administration.roles
      ";

    var roles = (await connection.QueryAsync<RoleResponse>(sql)).ToList();

    if (roles.Count == 0)
    {
      return Result.Failure<List<RoleResponse>>(UserErrors.RolesNotFound);
    }

    return roles;
  }
}
