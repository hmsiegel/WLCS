// <copyright file="AddAthleteToMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Meets;

public sealed record AddAthleteToMeetRequest(Guid MeetId, Guid AthleteId);
