// <copyright file="Register.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation.Users;

/// <summary>
/// Registers a user.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Register"/> class.
/// </remarks>
/// <param name="sender">An ISender instance.</param>
internal sealed class Register(ISender sender) : Endpoint<RegisterUserRequest, Guid>
{
  private readonly ISender _sender = sender;

  /// <inheritdoc/>
  public override void Configure()
  {
    Post("/users/register");
    AllowAnonymous();
    Tags(Presentation.Tags.Administration);
  }

  /// <inheritdoc/>
  public override async Task HandleAsync(RegisterUserRequest request, CancellationToken cancellationToken)
  {
    var command = new RegisterUserCommand(
      request.Email,
      request.Password,
      request.FirstName,
      request.LastName);

    var result = await _sender.Send(command, cancellationToken)
      .ConfigureAwait(false);

    if (!result.IsSuccess)
    {
      await SendResultAsync(result.ToMinimalApiResult())
        .ConfigureAwait(false);
    }

    await SendOkAsync(result.Value, cancellationToken)
        .ConfigureAwait(false);
  }
}
