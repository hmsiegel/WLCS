// <copyright file="EntityT.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public abstract class Entity<TEntityId>
  where TEntityId : class
{
  private readonly List<IDomainEvent> _domainEvents = [];

  protected Entity(TEntityId id)
  {
    Id = id;
  }

  protected Entity()
  {
  }

  public TEntityId Id { get; init; } = default!;

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
