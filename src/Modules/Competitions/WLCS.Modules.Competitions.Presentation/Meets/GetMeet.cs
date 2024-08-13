// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal static class GetMeet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets/{id}", async (Guid id, ISender sender) =>
    {
      var query = new GetMeetQuery(id);

      var meet = await sender.Send(query);

      return meet.Match(
        Results.Ok,
        ApiResult.Problem);
    })
    .WithTags(Tags.Competitions);
  }
}
