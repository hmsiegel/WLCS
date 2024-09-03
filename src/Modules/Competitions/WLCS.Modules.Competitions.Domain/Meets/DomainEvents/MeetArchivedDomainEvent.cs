// <copyright file="MeetArchivedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.DomainEvents;

public sealed class MeetArchivedDomainEvent(Guid meetId) : DomainEvent
{
  public Guid MeetId { get; init; } = meetId;
}
