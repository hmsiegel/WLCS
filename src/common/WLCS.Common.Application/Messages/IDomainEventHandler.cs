// <copyright file="IDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Messages;

/// <summary>
/// Handles domain events.
/// </summary>
/// <typeparam name="TDomainEvent">The domain event to be handled.</typeparam>
public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
  where TDomainEvent : IDomainEvent;
