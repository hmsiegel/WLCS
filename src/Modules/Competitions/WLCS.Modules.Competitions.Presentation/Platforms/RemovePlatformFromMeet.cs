// <copyright file="RemovePlatformFromMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Platforms;

internal sealed class RemovePlatformFromMeet(ISender sender) : Endpoint<PlatformMeetRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Delete("meets/{meetId}/platforms/{platformId}");
    Policies(Presentation.Permissions.UpdateMeets);
    Options(x => x.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(PlatformMeetRequest req, CancellationToken ct)
  {
    var command = new RemovePlatformFromMeetCommand(req.MeetId, req.PlatformId);
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
