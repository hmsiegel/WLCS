// <copyright file="AddAthleteToMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class AddAthleteToMeet(ISender sender) : EndpointWithoutRequest
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("meets/{meetId}/athletes/{athleteId}");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Meets));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var meetId = Route<Guid>("meetId");
    var athleteId = Route<Guid>("athleteId");

    var command = new AddAthleteToMeetCommand(
      meetId,
      athleteId);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok());
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }
}
