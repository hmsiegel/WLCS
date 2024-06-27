// <copyright file="RegisterUser.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

/// <summary>
/// Registers a user.
/// </summary>
internal sealed class RegisterUser : IEndpoint
{
  /// <inheritdoc/>
  public void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("users/register", async (RegisterUserRequest request, ISender sender) =>
    {
      var command = new RegisterUserCommand(
        request.Email,
        request.Password,
        request.FirstName,
        request.Password);

      var result = await sender.Send(command).ConfigureAwait(false);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .AllowAnonymous()
    .WithTags(Tags.Administration);
  }
}
