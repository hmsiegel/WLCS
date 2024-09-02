// <copyright file="AddAthleteToMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed record AddAthleteToMeetRequest(Guid MeetId, Guid AthleteId);
