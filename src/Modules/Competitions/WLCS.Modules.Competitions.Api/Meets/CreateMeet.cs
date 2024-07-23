// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Api.Meets;

public static class CreateMeet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets", async (Request request, CompetitionsDbContext context) =>
    {
      var meet = new Meet
      {
        Id = Guid.NewGuid(),
        Name = request.Name,
        Location = request.Location,
        Venue = request.Venue,
        StartDate = request.StartDate,
        EndDate = request.EndDate,
      };

      context.Meets.Add(meet);

      await context.SaveChangesAsync();

      return Results.Ok(meet.Id);
    })
    .WithTags(Tags.Competitions);
  }

  internal sealed record Request(
    string Name,
    string Location,
    string Venue,
    DateOnly StartDate,
    DateOnly EndDate);
}
