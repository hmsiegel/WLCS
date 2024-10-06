// <copyright file="ArchiveMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class ArchiveMeet(ISender sender) : EndpointWithoutRequest
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Put("meets/{meetId}/archive");
    Policies(Presentation.Permissions.UpdateMeets);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var meetId = Route<Guid>("meetId");

    var command = new ArchiveMeetCommand(
      meetId);

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
