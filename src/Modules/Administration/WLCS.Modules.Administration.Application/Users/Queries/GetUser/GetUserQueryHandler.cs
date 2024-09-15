// <copyright file="GetUserQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

internal sealed class GetUserQueryHandler(IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetUserQuery, UserResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    const string sql =
      $"""
       SELECT 
        id AS {nameof(UserResponse.Id)},
        email AS {nameof(UserResponse.Email)},
        first_name AS {nameof(UserResponse.FirstName)},
        last_name AS {nameof(UserResponse.LastName)}
      FROM administration.users
      WHERE id = @UserId
      """;

    var user = await connection.QuerySingleOrDefaultAsync<UserResponse>(sql, request);

    if (user is null)
    {
      return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
    }

    return user;
  }
}
