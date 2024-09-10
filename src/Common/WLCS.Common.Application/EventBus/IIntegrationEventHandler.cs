// <copyright file="IIntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
  where TIntegrationEvent : IIntegrationEvent
{
  Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}

public interface IIntegrationEventHandler
{
  Task Handle(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}
