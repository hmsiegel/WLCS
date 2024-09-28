// <copyright file="GetMeets.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class GetMeetsEndpoint(ISender sender) : EndpointWithoutRequest<List<MeetResponse>>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Get("meets");
    Permissions(Presentation.Permissions.GetMeets);
    Options(x => x.WithTags(Presentation.Tags.Meets));
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var query = new GetMeetsQuery();

    var meets = await _sender.Send(query, ct);

    if (meets.IsSuccess)
    {
      var result = meets.Value.Select(x => new MeetResponse(
        x.Id,
        x.Name,
        x.City,
        x.State,
        x.Venue,
        x.StartDate,
        x.EndDate)).ToList();

      await SendAsync(result, statusCode: StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(meets));
    }
  }
}
