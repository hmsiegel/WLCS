// <copyright file="GetMeetQueryHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Meets.Queries.GetMeet;

internal sealed class GetMeetQueryHandler(IDbConnectionFactory dbConnectionFactory)
  : IRequestHandler<GetMeetQuery, MeetResponse>
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task<MeetResponse> Handle(GetMeetQuery request, CancellationToken cancellationToken)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    const string sql =
      $"""
      SELECT
        id AS {nameof(MeetResponse.Id)},
        name AS {nameof(MeetResponse.Name)},
        location AS {nameof(MeetResponse.Location)},
        venue AS {nameof(MeetResponse.Venue)},
        start_date AS {nameof(MeetResponse.StartDate)},
        end_date AS {nameof(MeetResponse.EndDate)}
      FROM meets.competitions
      WHERE id = @Id
      """;

    MeetResponse? meet = await connection.QuerySingleOrDefaultAsync(sql, request);

    return meet!;
  }
}
