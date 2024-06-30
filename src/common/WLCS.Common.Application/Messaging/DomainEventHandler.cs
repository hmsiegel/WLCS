// <copyright file="DomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

/// <summary>
/// Handles domain events.
/// </summary>
/// <typeparam name="TDomainEvent">The domain event.</typeparam>
public abstract class DomainEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent>
  where TDomainEvent : IDomainEvent
{
  /// <inheritdoc/>
  public abstract Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);

  /// <inheritdoc/>
  public Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
  {
    return Handle((TDomainEvent)domainEvent, cancellationToken);
  }
}
