// <copyright file="UserRegisteredDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(
  IEventBus eventBus,
  ISender sender)
  : DomainEventHandler<UserRegisteredDomainEvent>
{
  private readonly IEventBus _eventBus = eventBus;
  private readonly ISender _sender = sender;

  public override async Task Handle(UserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken = default)
  {
    var query = new GetUserQuery(domainEvent.UserId);

    var result = await _sender.Send(query, cancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(GetUserQuery), result.Errors[0]);
    }

    await _eventBus.PublishAsync(
      new UserRegisteredIntegrationEvent(
        domainEvent.Id,
        domainEvent.OccurredOnUtc,
        result.Value.Id,
        result.Value.Email,
        result.Value.FirstName,
        result.Value.LastName),
      cancellationToken);
  }
}
