// <copyright file="RegisterUser.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class RegisterUser(ISender sender) : Endpoint<RegisterUserRequest>
{
  private readonly ISender _sender = sender;

  public override void Configure()
  {
    Post("users/register");
    AllowAnonymous();
    Options(o => o.WithTags(Presentation.Tags.Users));
  }

  public override async Task HandleAsync(RegisterUserRequest req, CancellationToken ct)
  {
    var user = new RegisterUserCommand(
      req.Email,
      req.Password,
      req.FirstName,
      req.LastName);

    var result = await _sender.Send(user, ct);

    if (result.IsSuccess)
    {
      await SendAsync(result.Value, StatusCodes.Status200OK, ct);
    }
    else
    {
      await SendResultAsync(ApiResults.Problem(result));
    }
  }
}
