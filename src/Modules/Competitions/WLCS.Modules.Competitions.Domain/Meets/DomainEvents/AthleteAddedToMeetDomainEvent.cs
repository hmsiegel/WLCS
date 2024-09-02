// <copyright file="AthleteAddedToMeetDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class AthleteAddedToMeetDomainEvent(Guid meetId, Guid athleteId) : DomainEvent
{
  public Guid MeetId { get; init; } = meetId;

  public Guid AthleteId { get; init; } = athleteId;
}
