// <copyright file="IntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

/// <summary>
/// Handles an integration event.
/// </summary>
/// <typeparam name="TIntegrationEvent">The type of integration event.</typeparam>
public abstract class IntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler<TIntegrationEvent>
  where TIntegrationEvent : IIntegrationEvent
{
  /// <inheritdoc/>
  public abstract Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);

  /// <inheritdoc/>
  public Task Handle(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default) =>
    Handle((TIntegrationEvent)integrationEvent, cancellationToken);
}
