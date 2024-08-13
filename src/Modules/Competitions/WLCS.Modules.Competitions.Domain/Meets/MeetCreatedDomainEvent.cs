// <copyright file="MeetCreatedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class MeetCreatedDomainEvent(Guid meetId) : DomainEvent
{
  public Guid MeetId { get; init; } = meetId;
}
