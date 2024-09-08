// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed partial class CreateMeet : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets", async (
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new CreateMeetCommand(
        request.Name,
        request.City,
        request.State,
        request.Venue,
        request.StartDate,
        request.EndDate);

      var result = await sender.Send(command, cancellationToken);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.CreateMeet)
    .WithTags(Tags.Meets);
  }

  internal sealed record Request(
    string Name,
    string City,
    string State,
    string Venue,
    DateOnly StartDate,
    DateOnly EndDate);
}
