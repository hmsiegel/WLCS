// <copyright file="CreateMeetRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation.MeetEndpoints;

/// <summary>
/// Represents the request to create a meet.
/// </summary>
public sealed record CreateMeetRequest(
  string Name,
  string Location,
  string Venue,
  LocalDate StartDate,
  LocalDate EndDate);
