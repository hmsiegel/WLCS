// <copyright file="UserProfileUpdatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users.DomainEvents;

/// <summary>
/// Represents a domain event that is raised when a user's profile is updated.
/// </summary>
public sealed class UserProfileUpdatedDomainEvent(
  Guid userId,
  string firstName,
  string lastName) : DomainEvent
{
  /// <summary>
  /// Gets the user's unique identifier.
  /// </summary>
  public Guid UserId { get; init; } = userId;

  /// <summary>
  /// Gets the user's first name.
  /// </summary>
  public string FirstName { get; init; } = firstName;

  /// <summary>
  /// Gets the user's last name.
  /// </summary>
  public string LastName { get; init; } = lastName;
}
