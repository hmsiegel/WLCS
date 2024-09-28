﻿// <copyright file="AddAthleteToMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class AddAthleteToMeet(ISender sender) : Endpoint<AddAthleteToMeetRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets/{meetId}/athletes/{athleteId}");
    Permissions(Presentation.Permissions.UpdateMeets);
    Options(x => x.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(AddAthleteToMeetRequest req, CancellationToken ct)
  {
    var command = new AddAthleteToMeetCommand(req.MeetId, req.AthleteId);
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
