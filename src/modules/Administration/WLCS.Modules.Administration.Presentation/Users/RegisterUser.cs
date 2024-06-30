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
    app.MapPost("users/register", async (Request request, ISender sender) =>
    {
      var command = new RegisterUserCommand(
        request.Email,
        request.Password,
        request.FirstName,
        request.LastName);

      var result = await sender.Send(command).ConfigureAwait(false);

      return result.Match(Results.Ok, ApiResults.Problem);
    })
    .AllowAnonymous()
    .WithTags(Tags.Administration);
  }

  /// <summary>
  /// Represents the request to register a user.
  /// </summary>
  /// <param name="Email">The email address.</param>
  /// <param name="Password">The password.</param>
  /// <param name="FirstName">The first name.</param>
  /// <param name="LastName">The last name.</param>
  internal sealed record class Request(
    string Email,
    string Password,
    string FirstName,
    string LastName);
}
