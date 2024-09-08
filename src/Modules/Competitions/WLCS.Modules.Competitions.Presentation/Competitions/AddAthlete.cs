// <copyright file="AddAthlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class AddAthlete : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("competitions/{competitionId}/athletes/{athleteId}", async (
      Guid competitionId,
      Guid athleteId,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new AddAthleteToCompetitionCommand(competitionId, athleteId);

      var result = await sender.Send(command, cancellationToken);

      return result.Match(Results.NoContent, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.ModifyCompetition)
    .WithTags(Tags.Competitions);
  }
}
