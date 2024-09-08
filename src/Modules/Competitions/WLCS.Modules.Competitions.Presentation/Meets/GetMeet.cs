// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed class GetMeet : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets/{id}", async (
      Guid id,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var query = new GetMeetQuery(id);

      var meet = await sender.Send(query, cancellationToken);

      return meet.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.GetMeets)
    .WithTags(Tags.Meets);
  }
}
