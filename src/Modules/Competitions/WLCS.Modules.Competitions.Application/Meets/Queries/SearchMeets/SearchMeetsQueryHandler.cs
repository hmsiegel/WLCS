// <copyright file="SearchMeetsQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.SearchMeets;

internal sealed class SearchMeetsQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IQueryHandler<SearchMeetsQuery, SearchMeetsResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<Result<SearchMeetsResponse>> Handle(SearchMeetsQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    var parameters = new SearchMeetsParameters(
      IsArchived: false,
      request.CompetitionId,
      request.StartDate,
      request.EndDate,
      request.PageSize,
      (request.Page - 1) * request.PageSize);

    var meets = await GetMeetsAsync(connection, parameters);

    var totalCount = await CountMeetsAsync(connection, parameters);

    return new SearchMeetsResponse(request.Page, request.PageSize, totalCount, meets);
  }

  private static async Task<IReadOnlyCollection<GetMeetResponse>> GetMeetsAsync(
    DbConnection connection,
    SearchMeetsParameters parameters)
  {
    const string sql = $"""
      SELECT
        id AS {nameof(GetMeetResponse.Id)},
        name AS {nameof(GetMeetResponse.Name)},
        city AS {nameof(GetMeetResponse.City)},
        state AS {nameof(GetMeetResponse.State)},
        venue AS {nameof(GetMeetResponse.Venue)},
        start_date AS {nameof(GetMeetResponse.StartDate)},
        end_date AS {nameof(GetMeetResponse.EndDate)}
      FROM
        competitions.meets
      WHERE
        is_archived = @IsArchived
        AND (@CompetitionId IS NULL OR competition_id = @CompetitionId)
        AND (@StartDate IS NULL OR start_date >= @StartDate)
        AND (@EndDate IS NULL OR end_date <= @EndDate)
      ORDER BY
        m.start_date
      LIMIT @Take
      OFFSET @Skip
      """;

    var meets = (await connection.QueryAsync<GetMeetResponse>(sql, parameters)).AsList();

    return meets;
  }

  private static async Task<int> CountMeetsAsync(DbConnection connection, SearchMeetsParameters parameters)
  {
    const string sql =
      """
      SELECT COUNT(*)
      FROM competitions.meets
      WHERE
        is_archived = @IsArchived
        AND (@CompetitionId IS NULL OR competition_id = @CompetitionId)
        AND (@StartDate IS NULL OR start_date >= @StartDate)
        AND (@EndDate IS NULL OR end_date <= @EndDate)
      """;

    var count = await connection.ExecuteScalarAsync<int>(sql, parameters);

    return count;
  }

  private sealed record SearchMeetsParameters(
    bool IsArchived,
    CompetitionId? CompetitionId,
    DateOnly? StartDate,
    DateOnly? EndDate,
    int Take,
    int Skip);
}
