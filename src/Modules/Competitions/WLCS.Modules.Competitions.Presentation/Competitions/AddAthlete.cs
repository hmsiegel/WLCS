// <copyright file="AddAthlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class AddAthlete(
  ISender sender)
  : Endpoint<AddAthleteToCompetitionRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("competitions/{competitionId}/athletes/{athleteId}");
    Policies(Presentation.Permissions.ModifyCompetition);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(AddAthleteToCompetitionRequest req, CancellationToken ct)
  {
    var command = new AddAthleteToCompetitionCommand(req.AthleteId, req.CompetitionId);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(Results.NoContent(), cancellation: ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
