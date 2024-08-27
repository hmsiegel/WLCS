// <copyright file="CreateMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed partial class CreateMeet(ISender sender) : Endpoint<MeetRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Meets));
  }

  public override async Task HandleAsync(MeetRequest request, CancellationToken ct)
  {
    var command = new CreateMeetCommand(
      request.Name,
      request.City,
      request.State,
      request.Venue,
      request.StartDate,
      request.EndDate);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok(result.Value));
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }
}
