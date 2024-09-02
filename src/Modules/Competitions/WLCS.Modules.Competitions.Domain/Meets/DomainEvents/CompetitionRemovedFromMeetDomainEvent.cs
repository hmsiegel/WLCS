// <copyright file="CompetitionRemovedFromMeetDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class CompetitionRemovedFromMeetDomainEvent(Guid meetId, Guid competitionId) : DomainEvent
{
  public Guid MeetId { get; private set; } = meetId;

  public Guid CompetitionId { get; private set; } = competitionId;
}
