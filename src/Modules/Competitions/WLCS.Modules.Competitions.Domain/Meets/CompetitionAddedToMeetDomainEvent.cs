// <copyright file="CompetitionAddedToMeetDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class CompetitionAddedToMeetDomainEvent(Guid meetId, Guid competitionId) : DomainEvent
{
  public Guid MeetId { get; init; } = meetId;

  public Guid CompetitionId { get; init; } = competitionId;
}
