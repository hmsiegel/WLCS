// <copyright file="CompetitionCreatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class CompetitionCreatedDomainEvent(Guid competitionId) : DomainEvent
{
  public Guid CompetitionId { get; init; } = competitionId;
}
