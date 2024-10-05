// <copyright file="CreatePlatform.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Platforms;

internal sealed class CreatePlatform(ISender sender) : Endpoint<PlatformRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets/{meetId}/platforms");
    Policies(Presentation.Permissions.UpdateMeets);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(PlatformRequest req, CancellationToken ct)
  {
    var meetId = Route<Guid>("meetId");

    var command = new CreatePlatformCommand(
      req.Name,
      meetId);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(result.Value, statusCode: StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
