// <copyright file="CompetitionMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Meets;

public sealed record CompetitionMeetRequest(Guid MeetId, Guid CompetitionId);
