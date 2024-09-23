// <copyright file="CreatePlatform.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Platforms;

internal sealed class CreatePlatform : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("meets/{meetId}/platform", async (
      Guid meetId,
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var command = new CreatePlatformCommand(
        request.Name,
        meetId);

      var result = await sender.Send(command, cancellationToken);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .RequireAuthorization(Permissions.CreateMeet)
    .WithTags(Tags.Meets);
  }

  internal sealed record Request(string Name);
}
