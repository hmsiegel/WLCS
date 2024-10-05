// <copyright file="Platform.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public sealed class Platform : Entity<PlatformId>
{
  private readonly List<Competition> _competitions = [];

  private Platform(
    MeetId meetId,
    PlatformName platformName,
    PlatformId? id = null)
  {
    MeetId = Guard.Against.Default(meetId);
    PlatformName = Guard.Against.Default(platformName);
    Id = id ?? PlatformId.CreateUnique();
  }

  private Platform()
  {
  }

  public MeetId MeetId { get; private set; } = default!;

  public PlatformName PlatformName { get; private set; } = default!;

  public IReadOnlyCollection<Competition> Competitions => [.. _competitions];

  public static Platform Create(
    MeetId meetId,
    PlatformName platformName)
  {
    var platform = new Platform(
      meetId,
      platformName);

    platform.Raise(new PlatformCreatedDomainEvent(platform.Id.Value, meetId.Value));

    return platform;
  }

  public Result AddCompetition(Competition competition)
  {
    if (_competitions.Contains(competition))
    {
      return Result.Failure(PlatformErrors.CompetitionAlreadyExists);
    }

    _competitions.Add(competition);

    return Result.Success();
  }

  public Result RemoveCompetition(Competition competition)
  {
    ArgumentNullException.ThrowIfNull(competition);

    if (!_competitions.Contains(competition))
    {
      return Result.Failure(PlatformErrors.CompetitionNotFound(competition.Id.Value));
    }

    _competitions.Remove(competition);

    return Result.Success();
  }

  public void Update(PlatformName platformName)
  {
    PlatformName = Guard.Against.Default(platformName);

    Raise(new PlatformUpdatedDomainEvent(Id.Value, MeetId.Value));
  }
}
