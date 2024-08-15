// <copyright file="MeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Meets;

internal sealed record MeetRequest(
  string Name,
  string Location,
  string Venue,
  DateOnly StartDate,
  DateOnly EndDate);
