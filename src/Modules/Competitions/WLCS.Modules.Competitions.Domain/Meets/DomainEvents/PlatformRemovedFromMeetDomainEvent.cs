// <copyright file="PlatformRemovedFromMeetDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class PlatformRemovedFromMeetDomainEvent(Guid meetId, Guid platformId) : DomainEvent
{
  public Guid MeetId { get; } = meetId;

  public Guid PlatformId { get; } = platformId;
}
