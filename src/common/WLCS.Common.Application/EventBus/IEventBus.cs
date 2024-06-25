// <copyright file="IEventBus.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

/// <summary>
/// Represents the <see cref="IEventBus"/> interface.
/// </summary>
public interface IEventBus
{
  /// <summary>
  /// Publishes the specified integration event.
  /// </summary>
  /// <typeparam name="T">The type to publish.</typeparam>
  /// <param name="integrationEvent">The integration event.</param>
  /// <param name="cancellationToken">The Cancellation Token.</param>
  /// <returns>A task.</returns>
  Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
    where T : IntegrationEvent;
}
