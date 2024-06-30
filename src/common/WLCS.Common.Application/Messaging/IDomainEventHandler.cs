// <copyright file="IDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

/// <summary>
/// Handles domain events.
/// </summary>
/// <typeparam name="TDomainEvent">The domain event to be handled.</typeparam>
public interface IDomainEventHandler<in TDomainEvent> : IDomainEventHandler
  where TDomainEvent : IDomainEvent
{
  /// <summary>
  /// Handles the domain event.
  /// </summary>
  /// <param name="domainEvent">The domain event.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>An asynchronous task.</returns>
  Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Handles domain events.
/// </summary>
public interface IDomainEventHandler
{
  /// <summary>
  /// Handles the domain event.
  /// </summary>
  /// <param name="domainEvent">The domain event.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>An asynchronous task.</returns>
  Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
