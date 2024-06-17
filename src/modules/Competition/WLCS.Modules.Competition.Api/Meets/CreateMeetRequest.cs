// <copyright file="CreateMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Api.Meets;

/// <summary>
/// Represents the request to create a meet.
/// </summary>
public sealed record CreateMeetRequest(
  string Name,
  string Location,
  string Venue,
  DateOnly StartDate,
  DateOnly EndDate);
