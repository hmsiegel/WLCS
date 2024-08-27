// <copyright file="RegisterUser.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using static WLCS.Modules.Administration.Presentation.Users.RegisterUser;

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class RegisterUser(ISender sender) : Endpoint<Request>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("users/register");
    AllowAnonymous();
    Options(x => x.WithTags(SwaggerTags.Users));
  }

  public override async Task HandleAsync(Request req, CancellationToken ct)
  {
    var user = new RegisterUserCommand(
      req.Email,
      req.Password,
      req.FirstName,
      req.LastName);

    var result = await _sender.Send(user, ct);

    if (result.IsSuccess)
    {
      await SendResultAsync(TypedResults.Ok(result.Value));
    }
    else
    {
      await SendResultAsync(TypedResults.Problem());
    }
  }

  internal sealed record Request(
    string Email,
    string Password,
    string FirstName,
    string LastName);
}
