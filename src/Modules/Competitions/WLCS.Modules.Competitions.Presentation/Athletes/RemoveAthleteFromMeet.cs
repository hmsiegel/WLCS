// <copyright file="RemoveAthleteFromMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Athletes;

internal sealed class RemoveAthleteFromMeet(ISender sender) : Endpoint<AthleteMeetRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Delete("meets/{meetId}/athletes/{athleteId}");
    Policies(Presentation.Permissions.UpdateMeets);
    Options(x => x.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(AthleteMeetRequest req, CancellationToken ct)
  {
    var command = new RemoveAthleteFromMeetCommand(req.MeetId, req.AthleteId);
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
