// <copyright file="AthleteRemovedFromMeetDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class AthleteRemovedFromMeetDomainEvent(Guid meetId, Guid athleteId) : DomainEvent
{
  public Guid MeetId { get; } = meetId;

  public Guid AthleteId { get; } = athleteId;
}
