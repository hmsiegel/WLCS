// <copyright file="AthleteRegisteredDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes;

public sealed class AthleteRegisteredDomainEvent(Guid athleteId) : DomainEvent
{
  public Guid AthleteId { get; set; } = athleteId;
}
