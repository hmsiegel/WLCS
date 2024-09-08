// <copyright file="GetMeets.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class GetMeets : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets", async (
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var query = new GetMeetsQuery();

      var meet = await sender.Send(query, cancellationToken);

      return meet.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.GetMeets)
    .WithTags(Tags.Meets);
  }
}
