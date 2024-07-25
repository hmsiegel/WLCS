// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.Domain.Abstractions;

namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class MeetCreatedDomainEvent(Guid meetId) : DomainEvent
{
  public Guid MeetId { get; init; } = meetId;
}
