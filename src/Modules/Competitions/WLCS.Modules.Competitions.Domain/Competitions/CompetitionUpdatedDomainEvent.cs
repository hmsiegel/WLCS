// <copyright file="CompetitionUpdatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class CompetitionUpdatedDomainEvent(Guid competitionId, Guid meetId) : DomainEvent
{
  public Guid CompetitionId { get; } = competitionId;

  public Guid MeetId { get; } = meetId;
}
