// <copyright file="IIntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

/// <summary>
/// Handles integration events.
/// </summary>
public interface IIntegrationEventHandler
{
  /// <summary>
  /// Handles the specified integration event.
  /// </summary>
  /// <param name="integrationEvent">The integration event.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>An asynchronous task.</returns>
  Task Handle(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Handles integration events of a specific type.
/// </summary>
/// <typeparam name="TIntegrationEvent">The integration event.</typeparam>
public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
  where TIntegrationEvent : IIntegrationEvent
{
  /// <summary>
  /// Handles the specified integration event.
  /// </summary>
  /// <param name="integrationEvent">The integration event.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>An asynchronous task.</returns>
  Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}
