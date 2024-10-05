// <copyright file="PlatformUpdatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public sealed class PlatformUpdatedDomainEvent(Guid platformId, Guid meetId) : DomainEvent
{
  public Guid PlatformId { get; private set; } = platformId;

  public Guid MeetId { get; } = meetId;
}
