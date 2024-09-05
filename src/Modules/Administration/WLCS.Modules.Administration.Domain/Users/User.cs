// <copyright file="User.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public sealed class User : Entity<UserId>
{
  private User(
    Email email,
    FirstName firstName,
    LastName lastName,
    string identityId,
    UserId? id = null)
  {
    Id = id ?? UserId.CreateUnique();
    Email = Guard.Against.Default(email);
    FirstName = Guard.Against.Default(firstName);
    LastName = Guard.Against.Default(lastName);
    IdentityId = Guard.Against.NullOrWhiteSpace(identityId);
  }

  private User()
  {
  }

  public Email Email { get; private set; } = default!;

  public FirstName FirstName { get; private set; } = default!;

  public LastName LastName { get; private set; } = default!;

  public string IdentityId { get; private set; } = default!;

  public static User Create(
    Email email,
    FirstName firstName,
    LastName lastName,
    string identityId)
  {
    var user = new User(email, firstName, lastName, identityId);

    user.Raise(new UserRegisteredDomainEvent(user.Id.Value));

    return user;
  }

  public void Update(
    FirstName firstName,
    LastName lastName)
  {
    if (FirstName == firstName && LastName == lastName)
    {
      return;
    }

    FirstName = Guard.Against.Default(firstName);
    LastName = Guard.Against.Default(lastName);

    Raise(new UserUpdatedDomainEvent(Id.Value));
  }
}
