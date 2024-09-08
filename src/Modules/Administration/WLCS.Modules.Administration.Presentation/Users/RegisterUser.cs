// <copyright file="RegisterUser.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

internal sealed class RegisterUser : IEndpoint
{
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("users/register", async (
      Request request,
      ISender sender,
      CancellationToken cancellationToken = default) =>
    {
      var user = new RegisterUserCommand(
        request.Email,
        request.Password,
        request.FirstName,
        request.LastName);

      var result = await sender.Send(user, cancellationToken);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .AllowAnonymous()
    .WithTags(Tags.Users);
  }

  internal sealed record Request(
    string Email,
    string Password,
    string FirstName,
    string LastName);
}
