// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class Meet : Entity<MeetId>
{
  private readonly List<Guid> _competitions = [];
  private readonly List<Guid> _athletes = [];

  private Meet(
    MeetName name,
    Location location,
    Venue venue,
    DateOnly startDate,
    DateOnly endDate,
    MeetId? id = null)
  {
    Id = id ?? MeetId.CreateUnique();
    Name = Guard.Against.Default(name);
    Location = Guard.Against.Default(location);
    Venue = Guard.Against.Default(venue);
    StartDate = Guard.Against.Default(startDate);
    EndDate = Guard.Against.Default(endDate);
  }

  private Meet()
  {
  }

  public MeetName Name { get; private set; } = default!;

  public Location Location { get; private set; } = default!;

  public Venue Venue { get; private set; } = default!;

  public DateOnly StartDate { get; private set; }

  public DateOnly EndDate { get; private set; }

  public bool IsActive { get; private set; } = true;

  public IReadOnlyCollection<Guid> Competitions => [.. _competitions];

  public IReadOnlyCollection<Guid> Athletes => [.. _athletes];

  public static Result<Meet> Create(
    MeetName name,
    Location location,
    Venue venue,
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

    meet.Raise(new MeetCreatedDomainEvent(meet.Id.Value));

    return meet;
  }

  public void ArchiveMeet()
  {
    IsActive = false;

    Raise(new MeetArchivedDomainEvent(Id.Value));
  }

  public void UpdateMeet(
    MeetName name,
    Location location,
    Venue venue,
    DateOnly startDate,
    DateOnly endDate)
  {
    Name = Guard.Against.Default(name);
    Location = Guard.Against.Default(location);
    Venue = Guard.Against.Default(venue);
    StartDate = Guard.Against.Default(startDate);
    EndDate = Guard.Against.Default(endDate);

    Raise(new MeetUpdatedDomainEvent(Id.Value));
  }

  public Result AddCompetition(Competition competition)
  {
    ArgumentNullException.ThrowIfNull(competition);

    if (Competitions.Contains(competition.Id.Value))
    {
      return Result.Failure(MeetErrors.CompetitionAlreadyAdded);
    }

    _competitions.Add(competition.Id.Value);

    Raise(new CompetitionAddedToMeetDomainEvent(Id.Value, competition.Id.Value));

    return Result.Success();
  }

  public Result RemoveCompetition(Competition competition)
  {
    ArgumentNullException.ThrowIfNull(competition);

    if (!Competitions.Contains(competition.Id.Value))
    {
      return Result.Failure(MeetErrors.CompetitionNotFound(competition.Id.Value));
    }

    _competitions.Remove(competition.Id.Value);

    Raise(new CompetitionRemovedFromMeetDomainEvent(Id.Value, competition.Id.Value));

    return Result.Success();
  }

  public void AddAthleteToMeet(Athlete athlete)
  {
    ArgumentNullException.ThrowIfNull(athlete);

    if (!_athletes.Contains(athlete.Id))
    {
      _athletes.Add(athlete.Id);

      Raise(new AthleteAddedToMeetDomainEvent(Id.Value, athlete.Id));
    }
  }
}
