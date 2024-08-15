// <copyright file="GetMeets.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class GetMeets(
  ISender sender,
  ICacheService cacheService)
  : EndpointWithoutRequest<IReadOnlyCollection<MeetResponse>>
{
  private readonly ISender _sender = sender;
  private readonly ICacheService _cacheService = cacheService;

  public override void Configure()
  {
    Get("meets");
    AllowAnonymous();
    Tags(SwaggerTags.Meets);
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var meetResponses = await _cacheService.GetAsync<IReadOnlyCollection<MeetResponse>>("meets", cancellationToken: ct);

    if (meetResponses is not null)
    {
      await SendAsync(meetResponses, statusCode: StatusCodes.Status200OK, ct);
    }

    var query = new GetMeetsQuery();

    var result = await _sender.Send(query, ct);

    if (result.IsSuccess)
    {
      await _cacheService.SetAsync("meets", result.Value, cancellationToken: ct);
      await SendAsync(result.Value, statusCode: StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResult.Problem(result));
    }
  }
}
