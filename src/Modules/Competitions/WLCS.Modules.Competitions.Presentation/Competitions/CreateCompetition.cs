// <copyright file="CreateCompetition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal static class CreateCompetition
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets/{meetId}/competition", async (Guid meetId, Request request, ISender sender) =>
    {
      var command = new CreateCompetitionCommand(
        meetId,
        request.Name,
        Scope.FromName(request.Scope),
        CompetitionType.FromName(request.CompetitionType),
        AgeDivision.FromName(request.AgeDivision));

      var competitionId = await sender.Send(command);

      return Results.Ok(competitionId);
    })
    .WithTags(Tags.Competitions);
  }

  internal sealed record Request(
    string Name,
    string Scope,
    string CompetitionType,
    string AgeDivision);
}
