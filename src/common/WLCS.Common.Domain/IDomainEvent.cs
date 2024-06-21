// <copyright file="IDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents a domain event.
/// </summary>
public interface IDomainEvent : INotification
{
  /// <summary>
  /// Gets the unique identifier of the domain event.
  /// </summary>
  Guid Id { get; }

  /// <summary>
  /// Gets the date and time the domain event occurred on in Coordinated Universal Time (UTC).
  /// </summary>
  DateTime OccurredOnUtc { get; }
}
