// <copyright file="EventBus.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.EventBus;

internal sealed class EventBus(IBus bus) : IEventBus
{
  private readonly IBus _bus = bus;

  public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
    where T : IIntegrationEvent
  {
    await _bus.Publish(integrationEvent, cancellationToken);
  }
}
