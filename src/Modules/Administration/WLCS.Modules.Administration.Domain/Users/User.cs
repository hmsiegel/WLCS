// <copyright file="User.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public sealed class User : Entity<UserId>
{
  private readonly List<Role> _roles = [];

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

  public IReadOnlyCollection<Role> Roles => [.. _roles];

  public static User Create(
    Email email,
    FirstName firstName,
    LastName lastName,
    string identityId)
  {
    var user = new User(email, firstName, lastName, identityId);

    user._roles.Add(Role.User);

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

  public void UpdateRole(Role role)
  {
    if (_roles.Contains(role))
    {
      return;
    }

    _roles.Add(role);

    Raise(new UserRoleUpdatedDomainEvent(Id.Value, role));
  }
}
