// <copyright file="MeetResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Application.Meets.Queries;

public sealed record MeetResponse(
  Guid Id,
  string Name,
  string City,
  string State,
  string Venue,
  DateOnly StartDate,
  DateOnly EndDate);
