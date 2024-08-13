// <copyright file="DomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
  protected DomainEvent()
  {
    Id = Guid.NewGuid();
    OccurredOnUtc = DateTime.UtcNow;
  }

  protected DomainEvent(Guid id, DateTime occurredOnUtc)
  {
    Id = id;
    OccurredOnUtc = occurredOnUtc;
  }

  public Guid Id { get; init; }

  public DateTime OccurredOnUtc { get; init; }
}
