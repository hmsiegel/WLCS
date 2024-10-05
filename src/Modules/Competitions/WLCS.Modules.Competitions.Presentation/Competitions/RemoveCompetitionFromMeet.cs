// <copyright file="RemoveCompetitionFromMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed class RemoveCompetitionFromMeet(ISender sender) : Endpoint<CompetitionMeetRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Delete("meets/{meetId}/competitions/{competitionId}");
    Policies(Presentation.Permissions.UpdateMeets);
    Options(x => x.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CompetitionMeetRequest req, CancellationToken ct)
  {
    var command = new RemoveCompetitionFromMeetCommand(req.MeetId, req.CompetitionId);
    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(result, statusCode: StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
