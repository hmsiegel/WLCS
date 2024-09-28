// <copyright file="GetUserQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUser;

internal sealed class GetUserQueryHandler(IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetUserQuery, GetUserResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<Result<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    const string sql =
      $"""
       SELECT 
        id AS {nameof(GetUserResponse.Id)},
        email AS {nameof(GetUserResponse.Email)},
        first_name AS {nameof(GetUserResponse.FirstName)},
        last_name AS {nameof(GetUserResponse.LastName)}
      FROM administration.users
      WHERE id = @UserId
      """;

    var user = await connection.QuerySingleOrDefaultAsync<GetUserResponse>(sql, request);

    if (user is null)
    {
      return Result.Failure<GetUserResponse>(UserErrors.NotFound(request.UserId));
    }

    return user;
  }
}
