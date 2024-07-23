// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Api.Meets;

public static class GetMeet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets/{id}", async (Guid id, CompetitionsDbContext context) =>
    {
      var meet = await context.Meets
        .Where(x => x.Id == id)
        .Select(x => new MeetResponse(
          x.Id,
          x.Name,
          x.Location,
          x.Venue,
          x.StartDate,
          x.EndDate))
        .SingleOrDefaultAsync();

      return meet is null
        ? Results.NotFound()
        : Results.Ok(meet);
    })
    .WithTags(Tags.Competitions);
  }
}
