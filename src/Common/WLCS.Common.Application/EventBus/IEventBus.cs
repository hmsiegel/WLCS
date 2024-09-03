// <copyright file="IEventBus.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

public interface IEventBus
{
  Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
    where T : IIntegrationEvent;
}
