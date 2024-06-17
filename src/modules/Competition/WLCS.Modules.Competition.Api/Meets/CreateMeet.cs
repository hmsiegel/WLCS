// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Api.Meets;

/// <summary>
///  Represents the create meet endpoint.
/// </summary>
public static class CreateMeet
{
  /// <summary>
  ///  The map endpoint method.
  /// </summary>
  /// <param name="app">The IEndpointRouteBuilder to pass in.</param>
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("competitions/meet", async (CreateMeetRequest request, CompetitionsDbContext dbContext) =>
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

      dbContext.Add(meet);

      await dbContext.SaveChangesAsync().ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);

      return Results.Ok(meet.Id);
    })
    .WithTags(Tags.Competition);
  }
}
