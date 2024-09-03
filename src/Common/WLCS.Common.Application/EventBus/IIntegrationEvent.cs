// <copyright file="IIntegrationEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.EventBus;

public interface IIntegrationEvent
{
  Guid Id { get; }

  DateTime OccurredOnUtc { get; }
}
