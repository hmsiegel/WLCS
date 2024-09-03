// <copyright file="AthleteCreatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Athletes;

public sealed class AthleteCreatedDomainEvent(Guid athleteId) : DomainEvent
{
  public Guid AthleteId { get; init; } = athleteId;
}
