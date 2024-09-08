// <copyright file="GetUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class GetUserProfile : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("users/profile", async (
      ClaimsPrincipal claims,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var query = new GetUserQuery(claims.GetUserId());

      var result = await sender.Send(query, cancellationToken);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.GetUser)
    .WithTags(Tags.Users);
  }
}
