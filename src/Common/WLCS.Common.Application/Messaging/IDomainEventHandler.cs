﻿// <copyright file="IDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : IDomainEventHandler
  where TDomainEvent : IDomainEvent
{
  Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}

public interface IDomainEventHandler
{
  Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
