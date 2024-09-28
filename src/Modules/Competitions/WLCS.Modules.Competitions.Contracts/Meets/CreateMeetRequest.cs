// <copyright file="CreateMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Meets;

public sealed record CreateMeetRequest(
  string Name,
  string City,
  string State,
  string Venue,
  DateOnly StartDate,
  DateOnly EndDate);
