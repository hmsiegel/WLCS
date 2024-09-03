// <copyright file="Entity.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public abstract class Entity : IEntity
{
  private readonly List<IDomainEvent> _domainEvents = [];

  protected Entity()
  {
  }

  public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

  public void ClearDomainEvents()
  {
    _domainEvents.Clear();
  }

  protected void Raise(IDomainEvent domainEvent)
  {
    _domainEvents.Add(domainEvent);
  }
}
