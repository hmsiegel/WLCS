// <copyright file="CreateCompetition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class CreateCompetition : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets/{meetId}/competition", async (
      Guid meetId,
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new CreateCompetitionCommand(
        meetId,
        request.Name,
        request.Scope,
        request.CompetitionType,
        request.AgeDivision);

      var result = await sender.Send(command, cancellationToken);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.CreateCompetition)
    .WithTags(Tags.Competitions);
  }

  internal sealed record Request(
    string Name,
    string Scope,
    string CompetitionType,
    string AgeDivision);
}
