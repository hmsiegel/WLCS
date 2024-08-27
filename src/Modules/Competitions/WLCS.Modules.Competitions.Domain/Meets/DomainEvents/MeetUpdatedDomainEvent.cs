// <copyright file="MeetUpdatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class MeetUpdatedDomainEvent(Guid meetId) : DomainEvent
{
  public Guid MeetId { get; } = meetId;
}
