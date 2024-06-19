// <copyright file="DomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents a domain event.
/// </summary>
public abstract class DomainEvent : IDomainEvent
{
  /// <summary>
  /// Initializes a new instance of the <see cref="DomainEvent"/> class.
  /// </summary>
  /// <param name="id">The unique identifier of the domain event.</param>
  /// <param name="occurredOnUtc">The date and time that the domain event occurred.</param>
  protected DomainEvent(Guid id, DateTime occurredOnUtc)
  {
    Id = id;
    OccurredOnUtc = occurredOnUtc;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="DomainEvent"/> class.
  /// </summary>
  protected DomainEvent()
  {
    Id = Guid.NewGuid();
    OccurredOnUtc = DateTime.UtcNow;
  }

  /// <inheritdoc/>
  public Guid Id { get; init; }

  /// <inheritdoc/>
  public DateTime OccurredOnUtc { get; init; }
}
