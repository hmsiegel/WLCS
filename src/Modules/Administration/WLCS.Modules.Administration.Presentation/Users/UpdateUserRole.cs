// <copyright file="UpdateUserRole.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class UpdateUserRole : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPut("users/{id}/roles", async (
      Guid id,
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new UpdateUserRoleCommand(
        id,
        request.RoleName);

      var result = await sender.Send(command, cancellationToken);

      result.Match(Results.NoContent, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.ModifyUser)
    .WithTags(Tags.Users);
  }

  internal sealed record Request(string RoleName);
}
