// <copyright file="User.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;

namespace WLCS.Modules.Administration.Domain.Users;

public sealed class User : Entity
{
  private User(
    string email,
    string firstName,
    string lastName,
    Guid? id = null)
  {
    Id = id ?? Guid.NewGuid();
    Email = Guard.Against.NullOrWhiteSpace(email);
    FirstName = Guard.Against.NullOrWhiteSpace(firstName);
    LastName = Guard.Against.NullOrWhiteSpace(lastName);
  }

  private User()
  {
  }

  public Guid Id { get; private set; }

  public string Email { get; private set; } = string.Empty;

  public string FirstName { get; private set; } = string.Empty;

  public string LastName { get; private set; } = string.Empty;

  public static User Create(
    string email,
    string firstName,
    string lastName)
  {
    var user = new User(email, firstName, lastName);

    user.Raise(new UserRegisteredDomainEvent(user.Id));

    return user;
  }

  public void Update(
    string firstName,
    string lastName)
  {
    if (FirstName == firstName && LastName == lastName)
    {
      return;
    }

    FirstName = Guard.Against.NullOrWhiteSpace(firstName);
    LastName = Guard.Against.NullOrWhiteSpace(lastName);

    Raise(new UserUpdatedDomainEvent(Id));
  }
}
