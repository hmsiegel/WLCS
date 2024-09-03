// <copyright file="IntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

public abstract class IntegrationEvent(Guid id, DateTime occurredOnUtc) : IIntegrationEvent
{
  public Guid Id { get; init; } = id;

  public DateTime OccurredOnUtc { get; init; } = occurredOnUtc;
}
