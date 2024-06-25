// <copyright file="GetUserQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

/// <summary>
/// Gets a user by their Id.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetUserQueryHandler"/> class.
/// </remarks>
/// <param name="dbConnectionFactory">The database connection factory.</param>
internal sealed class GetUserQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IQueryHandler<GetUserQuery, UserResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  /// <inheritdoc/>
  public async Task<Result<UserResponse>> Handle(GetUserQuery query, CancellationToken cancellationToken)
  {
    using var connection = await _dbConnectionFactory.OpenConnectionAsync(cancellationToken)
      .ConfigureAwait(false);

    const string sql =
      $"""
      SELECT
        id AS {nameof(UserResponse.Id)},
        first_name AS {nameof(UserResponse.FirstName)},
        last_name AS {nameof(UserResponse.LastName)},
        email AS {nameof(UserResponse.Email)}
      FROM administration.users
      WHERE id = @UserId
      """;

    var user = await connection.QuerySingleOrDefaultAsync<UserResponse>(sql, query)
      .ConfigureAwait(false);

    if (user is null)
    {
      return Result.Failure<UserResponse>(UserErrors.NotFound(query.UserId));
    }

    return user;
  }
}
