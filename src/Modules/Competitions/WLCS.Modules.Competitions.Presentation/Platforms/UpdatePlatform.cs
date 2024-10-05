// <copyright file="UpdatePlatform.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Platforms;

internal sealed class UpdatePlatform(ISender sender) : Endpoint<PlatformRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Put("meets/platform/{platformId}");
    Policies(Presentation.Permissions.UpdateMeets);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(PlatformRequest req, CancellationToken ct)
  {
    var platformId = Route<Guid>("platformId");

    var command = new UpdatePlatformCommand(
      platformId,
      req.Name);

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
