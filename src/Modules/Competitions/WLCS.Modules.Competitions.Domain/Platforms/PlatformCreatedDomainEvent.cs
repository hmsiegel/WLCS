// <copyright file="PlatformCreatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public sealed class PlatformCreatedDomainEvent(Guid platformId, Guid meetId) : DomainEvent
{
  public Guid PlatformId { get; init; } = platformId;

  public Guid MeetId { get; init; } = meetId;
}
