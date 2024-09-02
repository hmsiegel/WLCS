// <copyright file="AthleteCreatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Athletes;

public sealed class AthleteCreatedDomainEvent(Guid athleteId, Guid meetId) : DomainEvent
{
  public Guid AthleteId { get; init; } = athleteId;

  public Guid MeetId { get; } = meetId;
}
