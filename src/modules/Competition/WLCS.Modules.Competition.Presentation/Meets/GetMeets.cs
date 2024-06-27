// <copyright file="GetMeets.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation.Meets;

/// <summary>
/// The request to get a meet.
/// </summary>
internal sealed class GetMeets : IEndpoint
{
  /// <inheritdoc/>
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("meets", async (ISender sender) =>
    {
      var query = new GetMeetsQuery();
      var result = await sender.Send(query);
      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization("meets:read")
    .WithTags(Tags.Competition);
  }
}
