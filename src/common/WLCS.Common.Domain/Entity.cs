// <copyright file="Entity.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents an entity.
/// </summary>
public abstract class Entity
{
  private readonly List<IDomainEvent> _domainEvents = [];

  /// <summary>
  /// Initializes a new instance of the <see cref="Entity"/> class.
  /// </summary>
  protected Entity()
  {
  }

  /// <summary>
  /// Gets the domain events.
  /// </summary>
  public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

  /// <summary>
  /// Clears the domain events.
  /// </summary>
  public void ClearDomainEvents()
  {
    _domainEvents.Clear();
  }

  /// <summary>
  /// Raises a domain event.
  /// </summary>
  /// <param name="domainEvent">The domain event.</param>
  protected void Raise(IDomainEvent domainEvent)
  {
    _domainEvents.Add(domainEvent);
  }
}
