// <copyright file="UpdateCompetition.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class UpdateCompetition(ISender sender) : Endpoint<CompetitionRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Put("meets/competitions/{competitionId}");
    Policies(Presentation.Permissions.ModifyCompetition);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CompetitionRequest req, CancellationToken ct)
  {
    var competitionId = Route<Guid>("competitionId");

    var command = new UpdateCompetitionCommand(
      competitionId,
      req.Name,
      req.Scope,
      req.CompetitionType,
      req.AgeDivision);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendOkAsync(ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
