// <copyright file="Athlete.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Athletes;

public sealed class Athlete : Entity
{
  private Athlete(
    Guid id,
    string membership,
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    Gender gender,
    MeetId meetId)
  {
    Membership = Guard.Against.NullOrWhiteSpace(membership);
    FirstName = Guard.Against.NullOrWhiteSpace(firstName);
    LastName = Guard.Against.NullOrWhiteSpace(lastName);
    DateOfBirth = Guard.Against.Default(dateOfBirth);
    Gender = Guard.Against.Default(gender);
    Id = Guard.Against.Default(id);
    MeetId = meetId;
  }

  private Athlete()
  {
  }

  public Guid Id { get; private set; }

  public MeetId MeetId { get; private set; } = default!;

  public string Membership { get; private set; } = default!;

  public string FirstName { get; private set; } = default!;

  public string LastName { get; private set; } = default!;

  public DateOnly DateOfBirth { get; private set; } = default!;

  public Gender Gender { get; private set; } = default!;

  public string? Club { get; private set; } = default!;

  public string? Coach { get; private set; } = default!;

  public static Athlete Create(
    Guid id,
    MeetId meetId,
    string membership,
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    Gender gender)
  {
    ArgumentNullException.ThrowIfNull(meetId);

    var athlete = new Athlete(
      id: id,
      meetId: meetId,
      membership: membership,
      firstName: firstName,
      lastName: lastName,
      dateOfBirth: dateOfBirth,
      gender: gender);

    athlete.Raise(new AthleteCreatedDomainEvent(athlete.Id, meetId.Value));

    return athlete;
  }
}
