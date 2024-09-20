// <copyright file="UserRegisteredIntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Presentation.Users;

internal sealed class UserRegisteredIntegrationEventHandler(ISender sender) : IntegrationEventHandler<UserRegisteredIntegrationEvent>
{
  private readonly ISender _sender = sender;

  public override async Task Handle(UserRegisteredIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(integrationEvent);

    var command = new SendEmailCommand(
      integrationEvent.Email,
      "Welcome to WLCS",
      $"Hello {integrationEvent.FirstName} {integrationEvent.LastName}, welcome to WLCS!");

    var result = await _sender.Send(command, cancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(SendEmailCommand), result.Errors[0]);
    }
  }
}
