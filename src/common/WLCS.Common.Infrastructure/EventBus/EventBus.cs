// <copyright file="EventBus.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.EventBus;

/// <inheritdoc/>
/// <summary>
/// Initializes a new instance of the <see cref="EventBus"/> class.
/// </summary>
/// <param name="bus">The bus..</param>
internal sealed class EventBus(IBus bus) : IEventBus
{
  private readonly IBus _bus = bus;

  /// <inheritdoc/>
  public async Task PublishAsync<T>(
    T integrationEvent,
    CancellationToken cancellationToken = default)
    where T : IntegrationEvent
  {
    await _bus.Publish(integrationEvent, cancellationToken)
      .ConfigureAwait(false);
  }
}
