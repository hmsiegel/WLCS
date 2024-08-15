// <copyright file="GetMeets.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal static class GetMeets
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets", async (ISender sender, ICacheService cacheService) =>
    {
      var meetResponses = await cacheService.GetAsync<IReadOnlyCollection<MeetResponse>>("meets");

      if (meetResponses is not null)
      {
        return Results.Ok(meetResponses);
      }

      var query = new GetMeetsQuery();

      var result = await sender.Send(query);

      if (result.IsSuccess)
      {
        await cacheService.SetAsync("meets", result.Value);
      }

      return result.Match(
        Results.Ok,
        ApiResult.Problem);
    })
    .WithTags(Tags.Competitions);
  }
}
