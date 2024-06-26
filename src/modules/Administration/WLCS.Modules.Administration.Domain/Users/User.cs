﻿// <copyright file="User.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

/// <summary>
/// Represents a user.
/// </summary>
public sealed class User : Entity
{
  private readonly List<Role> _roles = [];

  private User(
    string email,
    string firstName,
    string lastName,
    string identityId,
    Guid? id = null)
  {
    Id = id ?? Guid.NewGuid();
    Email = email;
    FirstName = firstName;
    LastName = lastName;
    IdentityId = identityId;
  }

  private User()
  {
  }

  /// <summary>
  /// Gets the user's unique identifier.
  /// </summary>
  public Guid Id { get; private set; }

  /// <summary>
  /// Gets the user's email address.
  /// </summary>
  public string Email { get; private set; } = string.Empty;

  /// <summary>
  /// Gets the user's first name.
  /// </summary>
  public string FirstName { get; private set; } = string.Empty;

  /// <summary>
  /// Gets the user's last name.
  /// </summary>
  public string LastName { get; private set; } = string.Empty;

  /// <summary>
  /// Gets the user's identity identifier.
  /// </summary>
  public string IdentityId { get; private set; } = string.Empty;

  /// <summary>
  /// Gets the user's roles.
  /// </summary>
  public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

  /// <summary>
  /// Creates a new user.
  /// </summary>
  /// <param name="email">The user's email.</param>
  /// <param name="firstName">The user's first name.</param>
  /// <param name="lastName">The user's last name.</param>
  /// <param name="identityId">The identity identifier of the user.</param>
  /// <returns>An instance of the user.</returns>
  public static User Create(
    string email,
    string firstName,
    string lastName,
    string identityId)
  {
    var user = new User(
      email,
      firstName,
      lastName,
      identityId);

    user._roles.Add(Role.User);

    user.Raise(new UserRegisteredDomainEvent(user.Id));

    return user;
  }

  /// <summary>
  /// Updates the user's profile.
  /// </summary>
  /// <param name="firstName">The user's first name.</param>
  /// <param name="lastName">The user's last name.</param>
  public void Update(
    string firstName,
    string lastName)
  {
    if (FirstName == firstName && LastName == lastName)
    {
      return;
    }

    FirstName = firstName;
    LastName = lastName;

    Raise(new UserProfileUpdatedDomainEvent(Id, FirstName, LastName));
  }
}
