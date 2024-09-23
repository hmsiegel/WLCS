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

  public void AddCompetition(Competition competition)
  {
    if (_competitions.Contains(competition))
    {
      return;
    }

    _competitions.Add(competition);
  }
}
