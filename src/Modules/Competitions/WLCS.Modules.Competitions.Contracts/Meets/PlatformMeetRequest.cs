// <copyright file="PlatformMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Meets;

public sealed record PlatformMeetRequest(Guid MeetId, Guid PlatformId);
