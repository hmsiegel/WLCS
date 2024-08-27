// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class GetMeet(ISender sender) : EndpointWithoutRequest<MeetResponse>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Get("meets/{id}");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Meets));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var id = Route<Guid>("id");

    var query = new GetMeetQuery(id);

    var meet = await _sender.Send(query, ct);

    if (meet.IsSuccess)
    {
      await SendAsync(meet.Value, statusCode: StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResult.Problem(meet));
    }
  }
}
