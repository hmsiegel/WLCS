// <copyright file="UserRegisteredDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

/// <summary>
/// Initializes a new instance of the <see cref="UserRegisteredDomainEventHandler"/> class.
/// </summary>
/// <param name="sender">An implemenation of ISender.</param>
/// <param name="eventBus">An implemenation of IEventBus.</param>
internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus eventBus) : IDomainEventHandler<UserRegisteredDomainEvent>
{
  private readonly ISender _sender = sender;
  private readonly IEventBus _eventBus = eventBus;

  /// <inheritdoc/>
  public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
  {
    var result = await _sender.Send(
      new GetUserQuery(notification.UserId),
      cancellationToken)
      .ConfigureAwait(false);

    if (result.IsFailure)
    {
      throw new WLCSException(nameof(GetUserQuery), result.Error);
    }

    await _eventBus.PublishAsync(
      new UserRegisteredIntegrationEvent(
        result.Value.Id,
        result.Value.Email,
        result.Value.FirstName,
        result.Value.LastName,
        notification.Id,
        notification.OccurredOnUtc),
      cancellationToken)
      .ConfigureAwait(false);
  }
}
