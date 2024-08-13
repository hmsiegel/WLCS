// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class Meet : Entity
{
  private readonly List<Competition> _competitions = [];

  private Meet(
    string name,
    string location,
    string venue,
    DateOnly startDate,
    DateOnly endDate,
    Guid? id = null)
  {
    Id = id ?? Guid.NewGuid();
    Name = Guard.Against.NullOrWhiteSpace(name);
    Location = Guard.Against.NullOrWhiteSpace(location);
    Venue = Guard.Against.NullOrWhiteSpace(venue);
    StartDate = Guard.Against.Default(startDate);
    EndDate = Guard.Against.Default(endDate);
  }

  private Meet()
  {
  }

  public Guid Id { get; private set; }

  public string Name { get; private set; } = string.Empty;

  public string Location { get; private set; } = string.Empty;

  public string Venue { get; private set; } = string.Empty;

  public DateOnly StartDate { get; private set; }

  public DateOnly EndDate { get; private set; }

  public bool IsActive { get; private set; } = true;

  public IReadOnlyCollection<Competition> Competitions => [.. _competitions];

  public static Result<Meet> Create(
    string name,
    string location,
    string venue,
    DateOnly startDate,
    DateOnly endDate)
  {
    if (endDate < startDate)
    {
      return Result.Failure<Meet>(MeetErrors.EndDatePrecedesStartDate);
    }

    var meet = new Meet(
      name,
      location,
      venue,
      startDate,
      endDate);

    meet.Raise(new MeetCreatedDomainEvent(meet.Id));

    return meet;
  }

  public void ArchiveMeet()
  {
    IsActive = false;

    Raise(new MeetArchivedDomainEvent(Id));
  }

  public void UpdateMeet(
    string name,
    string location,
    string venue,
    DateOnly startDate,
    DateOnly endDate)
  {
    Name = Guard.Against.NullOrWhiteSpace(name);
    Location = Guard.Against.NullOrWhiteSpace(location);
    Venue = Guard.Against.NullOrWhiteSpace(venue);
    StartDate = Guard.Against.Default(startDate);
    EndDate = Guard.Against.Default(endDate);

    Raise(new MeetUpdatedDomainEvent(Id));
  }

  public Result AddCompetition(Competition competition)
  {
    ArgumentNullException.ThrowIfNull(competition);

    if (Competitions.Contains(competition))
    {
      return Result.Failure(MeetErrors.CompetitionAlreadyAdded);
    }

    _competitions.Add(competition);

    Raise(new CompetitionAddedToMeetDomainEvent(Id, competition.Id));

    return Result.Success();
  }
}
