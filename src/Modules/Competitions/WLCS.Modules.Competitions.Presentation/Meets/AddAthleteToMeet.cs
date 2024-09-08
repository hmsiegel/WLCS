// <copyright file="AddAthleteToMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class AddAthleteToMeet : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets/{meetId}/athletes/{athleteId}", async (
      Guid meetId,
      Guid athleteId,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new AddAthleteToMeetCommand(
        meetId,
        athleteId);

      var result = await sender.Send(command, cancellationToken);

      return result.Match(Results.NoContent, ApiResults.Problem);
    })
    .WithTags(Tags.Meets)
    .RequireAuthorization(Permissions.UpdateMeets);
  }
}
