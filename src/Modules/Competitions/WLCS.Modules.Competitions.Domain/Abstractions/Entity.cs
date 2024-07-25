// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>


// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Abstractions;

public abstract class Entity
{
  private readonly List<IDomainEvent> _domainEvents = [];

  protected Entity()
  {
  }

  public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

  public void ClearDomainEvents()
  {
    _domainEvents.Clear();
  }

  protected void Raise(IDomainEvent domainEvent)
  {
    _domainEvents.Add(domainEvent);
  }
}
