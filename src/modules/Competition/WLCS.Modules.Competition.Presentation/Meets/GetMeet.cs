// <copyright file="GetMeet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation.Meets;

/// <summary>
/// The request to get a meet.
/// </summary>
internal sealed class GetMeet : IEndpoint
{
  /// <inheritdoc/>
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets/{id}", async (Guid id, ISender sender) =>
    {
      var query = new GetMeetQuery(id);
      var result = await sender.Send(query).ConfigureAwait(false);
      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization("meets:read")
    .WithTags(Tags.Competition);
  }
}
