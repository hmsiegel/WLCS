// <copyright file="Athlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes;

public sealed class Athlete : Entity<AthleteId>
{
  private Athlete(
    Membership membership,
    FirstName firstName,
    LastName lastName,
    DateOnly dateOfBirth,
    Gender gender,
    Email email,
    AthleteId? id = null)
  {
    Membership = Guard.Against.Default(membership);
    FirstName = Guard.Against.Default(firstName);
    LastName = Guard.Against.Default(lastName);
    DateOfBirth = Guard.Against.Default(dateOfBirth);
    Gender = Guard.Against.Default(gender);
    Email = Guard.Against.Default(email);
    Id = id ?? AthleteId.CreateUnique();
  }

  private Athlete()
  {
  }

  public Membership Membership { get; private set; } = default!;

  public FirstName FirstName { get; private set; } = default!;

  public LastName LastName { get; private set; } = default!;

  public DateOnly DateOfBirth { get; private set; } = default!;

  public Gender Gender { get; private set; } = default!;

  public Club? Club { get; private set; } = default!;

  public Address? Address { get; private set; } = default!;

  public Email Email { get; private set; } = default!;

  public PhoneNumber? PhoneNumber { get; private set; } = default!;

  public Coach? Coach { get; private set; } = default!;

  public static Athlete Create(
    Membership membership,
    FirstName firstName,
    LastName lastName,
    DateOnly dateOfBirth,
    Email email,
    Gender gender)
  {
    var athlete = new Athlete(
      membership: membership,
      firstName: firstName,
      lastName: lastName,
      dateOfBirth: dateOfBirth,
      gender: gender,
      email: email);

    athlete.Raise(new AthleteCreatedDomainEvent(athlete.Id.Value));

    return athlete;
  }
}
