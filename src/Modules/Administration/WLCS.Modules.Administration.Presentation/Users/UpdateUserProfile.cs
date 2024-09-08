// <copyright file="UpdateUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class UpdateUserProfile : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPut("users/update", async (
      ClaimsPrincipal claims,
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new UpdateUserCommand(
       claims.GetUserId(),
       request.FirstName,
       request.LastName);

      var result = await sender.Send(command, cancellationToken);

      result.Match(Results.NoContent, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.ModifyUser)
    .WithTags(Tags.Users);
  }

  internal sealed record Request(string FirstName, string LastName);
}
