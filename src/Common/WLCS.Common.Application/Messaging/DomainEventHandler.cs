// <copyright file="DomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

public abstract class DomainEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
  public abstract Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);

  public Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
  {
    return Handle((TDomainEvent)domainEvent, cancellationToken);
  }
}
