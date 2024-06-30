// <copyright file="UserRegisteredDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

/// <summary>
/// Initializes a new instance of the <see cref="UserRegisteredDomainEventHandler"/> class.
/// </summary>
/// <param name="sender">An implemenation of ISender.</param>
/// <param name="eventBus">An implemenation of IEventBus.</param>
internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus eventBus)
  : DomainEventHandler<UserRegisteredDomainEvent>
{
  private readonly ISender _sender = sender;
  private readonly IEventBus _eventBus = eventBus;

  /// <inheritdoc/>
  public override async Task Handle(
    UserRegisteredDomainEvent domainEvent,
    CancellationToken cancellationToken)
  {
    var result = await _sender.Send(
      new GetUserQuery(domainEvent.UserId),
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
        domainEvent.Id,
        domainEvent.OccurredOnUtc),
      cancellationToken)
      .ConfigureAwait(false);
  }
}
