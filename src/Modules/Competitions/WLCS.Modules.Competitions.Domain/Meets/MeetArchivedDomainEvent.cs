﻿// <copyright file="MeetArchivedDomainEvent.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets;

public sealed class MeetArchivedDomainEvent(Guid meetId) : DomainEvent
{
  public Guid MeetId { get; } = meetId;
}
