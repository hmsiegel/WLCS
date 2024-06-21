// <copyright file="UserRegisteredDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users.DomainEvents;

/// <summary>
/// Represents a domain event that is raised when a user is registered.
/// </summary>
public sealed class UserRegisteredDomainEvent(Guid userId) : DomainEvent
{
  /// <summary>
  /// Gets the user's unique identifier.
  /// </summary>
  public Guid UserId { get; init; } = userId;
}
