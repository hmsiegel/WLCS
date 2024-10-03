// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class CreateMeet(
  ISender sender)
  : Endpoint<CreateMeetRequest, Guid>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets");
    Policies(Presentation.Permissions.CreateMeet);
    Options(opt => opt.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CreateMeetRequest req, CancellationToken ct)
  {
    var command = new CreateMeetCommand(
      req.Name,
      req.City,
      req.State,
      req.Venue,
      req.StartDate,
      req.EndDate);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendAsync(result.Value, cancellation: ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
