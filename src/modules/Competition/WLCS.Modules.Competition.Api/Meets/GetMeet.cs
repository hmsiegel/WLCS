// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Api.Meets;

/// <summary>
/// Represents the get meet endpoint.
/// </summary>
public static class GetMeet
{
  /// <summary>
  /// Represents the map endpoint method.
  /// </summary>
  /// <param name="app">The IEndpointRouteBuilder to pass in.</param>
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("competitions/meets/{id}", async (Guid id, CompetitionsDbContext dbContext) =>
    {
      var meet = await dbContext.Meets
        .Where(m => m.Id == id)
        .Select(m => new MeetResponse(
          m.Id,
          m.Name,
          m.Location,
          m.Venue,
          m.StartDate,
          m.EndDate))
        .SingleOrDefaultAsync().ConfigureAwait(false);

      return meet is null ? Results.NotFound() : Results.Ok(meet);
    })
      .WithTags(Tags.Competition);
  }
}
