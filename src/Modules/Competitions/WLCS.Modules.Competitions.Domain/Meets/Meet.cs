// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class Meet : Entity<MeetId>
{
  private readonly List<Guid> _competitions = [];
  private readonly List<Guid> _athletes = [];
  private readonly List<Guid> _platforms = [];

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

  public IReadOnlyCollection<Guid> Platforms => [.. _platforms];

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

  public void ToggleIsActive(bool isActive)
  {
    if (!isActive)
    {
      IsActive = true;
      Raise(new MeetReactivatedDomainEvent(Id.Value));
    }
    else
    {
      IsActive = false;
      Raise(new MeetArchivedDomainEvent(Id.Value));
    }
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

    if (_competitions.Contains(competition.Id.Value))
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

    if (!_competitions.Contains(competition.Id.Value))
    {
      return Result.Failure(MeetErrors.CompetitionNotFound(competition.Id.Value));
    }

    _competitions.Remove(competition.Id.Value);

    Raise(new CompetitionRemovedFromMeetDomainEvent(Id.Value, competition.Id.Value));

    return Result.Success();
  }

  public Result AddAthlete(Athlete athlete)
  {
    ArgumentNullException.ThrowIfNull(athlete);

    if (_athletes.Contains(athlete.Id))
    {
      return Result.Failure(MeetErrors.AthleteAlreadyAdded);
    }

    _athletes.Add(athlete.Id);

    Raise(new AthleteAddedToMeetDomainEvent(Id.Value, athlete.Id));

    return Result.Success();
  }

  public Result RemoveAthlete(Athlete athlete)
  {
    ArgumentNullException.ThrowIfNull(athlete);

    if (!_athletes.Contains(athlete.Id))
    {
      return Result.Failure(MeetErrors.AthleteNotFound(athlete.Id));
    }

    _athletes.Remove(athlete.Id);

    Raise(new AthleteRemovedFromMeetDomainEvent(Id.Value, athlete.Id));

    return Result.Success();
  }

  public Result AddPlatform(Platform platform)
  {
    ArgumentNullException.ThrowIfNull(platform);

    if (_platforms.Contains(platform.Id.Value))
    {
      return Result.Failure(MeetErrors.PlatformAlreadyAdded);
    }

    _platforms.Add(platform.Id.Value);

    Raise(new PlatformAddedToMeetDomainEvent(Id.Value, platform.Id.Value));

    return Result.Success();
  }

  public Result RemovePlatform(Platform platform)
  {
    ArgumentNullException.ThrowIfNull(platform);

    if (!_platforms.Contains(platform.Id.Value))
    {
      return Result.Failure(MeetErrors.PlatformNotFound(platform.Id.Value));
    }

    _platforms.Remove(platform.Id.Value);

    Raise(new PlatformRemovedFromMeetDomainEvent(Id.Value, platform.Id.Value));

    return Result.Success();
  }
}
