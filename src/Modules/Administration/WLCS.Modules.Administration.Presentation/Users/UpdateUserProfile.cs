// <copyright file="UpdateUserProfile.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using static WLCS.Modules.Administration.Presentation.Users.UpdateUserProfile;

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class UpdateUserProfile(ISender sender) : Endpoint<Request>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Put("users/{id}/profile");
    AllowAnonymous();
    Tags(SwaggerTags.Users);
  }

  public override async Task HandleAsync(Request req, CancellationToken ct)
  {
    var id = Route<Guid>("id");

    var command = new UpdateUserCommand(
      id,
      req.FirstName,
      req.LastName);

    var result = await _sender.Send(command, ct);

    if (result.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok(result));
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }

  internal sealed record Request(string FirstName, string LastName);
}
