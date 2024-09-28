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
    Gender gender)
  {
    Membership = Guard.Against.NullOrWhiteSpace(membership);
    FirstName = Guard.Against.NullOrWhiteSpace(firstName);
    LastName = Guard.Against.NullOrWhiteSpace(lastName);
    DateOfBirth = Guard.Against.Default(dateOfBirth);
    Gender = Guard.Against.Default(gender);
    Id = Guard.Against.Default(id);
  }

  private Athlete()
  {
  }

  public Guid Id { get; private set; }

  public MeetId? MeetId { get; private set; } = default!;

  public string Membership { get; private set; } = default!;

  public string FirstName { get; private set; } = default!;

  public string LastName { get; private set; } = default!;

  public DateOnly DateOfBirth { get; private set; } = default!;

  public Gender Gender { get; private set; } = default!;

  public string? Club { get; private set; } = default!;

  public string? Coach { get; private set; } = default!;

  public string WeightClass { get; private set; } = default!;

  public AgeDivision AgeDivision { get; private set; } = default!;

  public int EntryTotal { get; private set; } = default!;

  public static Athlete Create(
    Guid id,
    string membership,
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    Gender gender)
  {
    var athlete = new Athlete(
      id: id,
      membership: membership,
      firstName: firstName,
      lastName: lastName,
      dateOfBirth: dateOfBirth,
      gender: gender);

    athlete.Raise(new AthleteCreatedDomainEvent(athlete.Id));

    return athlete;
  }

  public void Update(
    string firstName,
    string lastName,
    string club,
    string coach)
  {
    FirstName = Guard.Against.NullOrWhiteSpace(firstName);
    LastName = Guard.Against.NullOrWhiteSpace(lastName);
    Club = Guard.Against.NullOrWhiteSpace(club);
    Coach = Guard.Against.NullOrWhiteSpace(coach);
  }

  public void AddToMeet(MeetId meetId)
  {
    MeetId = Guard.Against.Default(meetId);
  }
}
