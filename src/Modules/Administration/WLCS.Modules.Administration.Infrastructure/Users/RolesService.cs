// <copyright file="RolesService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

internal sealed class RolesService(
  IDbConnectionFactory dbConnectionFactory,
  ILogger<RolesService> logger)
  : IRolesService
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
  private readonly ILogger<RolesService> _logger = logger;

  public async Task<Result> AddRole(
    Guid userId,
    string roleName,
    CancellationToken cancellationToken = default)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();
    await using var transaction = await connection.BeginTransactionAsync(cancellationToken);

    try
    {
      string sql =
        $"""
        SELECT * 
        FROM administration.roles 
        WHERE Name = @Name
        """;

      var role = await connection.QuerySingleOrDefaultAsync<Role>(
        sql,
        roleName,
        transaction);

      if (role == null)
      {
        return Result.Failure(UserErrors.RoleNotFound(roleName));
      }

      sql =
        $"""
        SELECT * 
        FROM administration.user_roles 
        WHERE user_id = @UserId 
        AND roles_name = @RoleName
        """;

      var userRole = await connection.QuerySingleOrDefaultAsync<Role>(
        sql,
        new { UserId = userId, RoleName = roleName },
        transaction);

      if (userRole != null)
      {
        return Result.Failure(UserErrors.UserAlreadyHasRole);
      }

      sql =
        $"""
        INSERT INTO user_roles (user_id, roles_name)
        VALUES (@UserId, @RoleName)
        """;

      await connection.ExecuteAsync(
        sql,
        new { UserId = userId, RoleId = roleName },
        transaction);

      await transaction.CommitAsync(cancellationToken);

      return Result.Success();
    }
    catch (Exception exception)
    {
      await transaction.RollbackAsync(cancellationToken);

      UserLoggingExtensions.UserRoleError(
        _logger,
        exception);

      return Result.Failure(UserErrors.RoleError);
    }
  }

  public Task<Result> RemoveRole(Guid userId, string roleName, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public async Task<Result> UpdateRole(
    Guid userId,
    string roleName,
    CancellationToken cancellationToken = default)
  {
    using var connection = await _dbConnectionFactory.OpenConnectionAsync();
    using var transaction = await connection.BeginTransactionAsync(cancellationToken);

    try
    {
      string sql =
        $"""
        SELECT 
          name AS {nameof(Role.Name)}
        FROM administration.roles 
        WHERE name = @RoleName
        """;

      var role = await connection.QuerySingleOrDefaultAsync<Role>(
        sql,
        new { RoleName = roleName },
        transaction: transaction);

      if (role == null)
      {
        return Result.Failure(UserErrors.RoleNotFound(roleName));
      }

      sql =
        $"""
        SELECT
          user_id AS {nameof(User.Id)},
          roles_name AS {nameof(Role.Name)}
        FROM administration.user_roles 
        WHERE user_id = @UserId 
        AND roles_name = @RoleName
        """;

      var userRole = await connection.QuerySingleOrDefaultAsync(
        sql,
        new { UserId = userId, RoleName = roleName },
        transaction);

      if (userRole != null)
      {
        return Result.Failure(UserErrors.UserAlreadyHasRole);
      }

      sql =
        $"""
        UPDATE administration.user_roles 
        SET roles_name = @RoleName
        WHERE user_id = @UserId
        """;

      await connection.ExecuteAsync(
        sql,
        new { UserId = userId, RoleName = roleName },
        transaction);

      await transaction.CommitAsync(cancellationToken);

      return Result.Success();
    }
    catch (Exception exception)
    {
      await transaction.RollbackAsync(cancellationToken);

      UserLoggingExtensions.UserRoleError(
        _logger,
        exception);

      return Result.Failure(UserErrors.RoleError);
    }
  }
}
