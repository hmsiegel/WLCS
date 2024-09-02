// <copyright file="AddAthlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class AddAthlete(ISender sender) : EndpointWithoutRequest
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("competitions/{competitionId}/athletes/{athleteId}");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Competitions));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var competitionId = Route<Guid>("competitionId");
    var athleteId = Route<Guid>("athleteId");

    var command = new AddAthleteToCompetitionCommand(competitionId, athleteId);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok());
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }
}
