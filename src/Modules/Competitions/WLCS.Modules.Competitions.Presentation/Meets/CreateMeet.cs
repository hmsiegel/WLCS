// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal static class CreateMeet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets", async (Request request, ISender sender) =>
    {
      var command = new CreateMeetCommand(
        request.Name,
        request.Location,
        request.Venue,
        request.StartDate,
        request.EndDate);

      var meetId = await sender.Send(command);

      return Results.Ok(meetId);
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
