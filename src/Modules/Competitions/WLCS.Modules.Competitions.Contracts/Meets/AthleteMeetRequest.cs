// <copyright file="AthleteMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Meets;

public sealed record AthleteMeetRequest(Guid MeetId, Guid AthleteId);
