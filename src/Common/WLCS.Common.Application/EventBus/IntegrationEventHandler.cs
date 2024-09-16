﻿// <copyright file="IntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

public abstract class IntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler<TIntegrationEvent>
  where TIntegrationEvent : IIntegrationEvent
{
  public abstract Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);

  public Task Handle(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
  {
    return Handle((TIntegrationEvent)integrationEvent, cancellationToken);
  }
}