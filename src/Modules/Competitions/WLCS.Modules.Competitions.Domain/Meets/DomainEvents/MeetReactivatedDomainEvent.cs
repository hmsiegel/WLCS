// <copyright file="MeetReactivatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class MeetReactivatedDomainEvent(Guid meetId) : DomainEvent
{
  public Guid MeetId { get; } = meetId;
}
