// <copyright file="UserRegisteredDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(
  ISender sender,
  IEventBus eventBus)
  : DomainEventHandler<UserRegisteredDomainEvent>
{
  private readonly ISender _sender = sender;
  private readonly IEventBus _eventBus = eventBus;

  public override async Task Handle(UserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken = default)
  {
    var query = new GetUserQuery(domainEvent.UserId);

    var result = await _sender.Send(query, cancellationToken);

    if (result.IsFailure)
    {
      throw new WlcsException(nameof(GetUserQuery), result.Errors[0]);
    }

    var user = result.Value;

    await _eventBus.PublishAsync(
      new UserRegisteredIntegrationEvent(
      domainEvent.Id,
      domainEvent.OccurredOnUtc,
      user.Id,
      user.Email,
      user.FirstName,
      user.LastName),
      cancellationToken);
  }
}
