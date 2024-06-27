// <copyright file="GetUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

/// <summary>
/// Get user profile endpoint.
/// </summary>
internal sealed class GetUserProfile : IEndpoint
{
  /// <inheritdoc/>
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("users/profile", async (ClaimsPrincipal claims, ISender sender) =>
    {
      var query = new GetUserQuery(claims.GetUserId());
      var result = await sender.Send(query).ConfigureAwait(false);
      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization("users:read")
    .WithTags(Tags.Administration);
  }
}
