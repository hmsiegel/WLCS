// <copyright file="MeetResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Meets.Queries.GetMeet;

/// <summary>
/// Represents a meet response.
/// </summary>
/// <param name="Id">The unique identifier of the meet.</param>
/// <param name="Name">The name of the meet.</param>
/// <param name="Location">The city where the meet id being held.</param>
/// <param name="Venue">The venue where the meet is being held.</param>
/// <param name="StartDate">The start date of the meet.</param>
/// <param name="EndDate">The end date of the meet.</param>
public sealed record MeetResponse(
  Guid Id,
  string Name,
  LocalDate StartDate,
  LocalDate EndDate,
  string Location,
  string Venue)
{
  /// <summary>
  /// Initializes a new instance of the <see cref="MeetResponse"/> class.
  /// </summary>
  public MeetResponse()
    : this(
        Guid.Empty,
        string.Empty,
        LocalDate.MinIsoValue,
        LocalDate.MinIsoValue,
        string.Empty,
        string.Empty)
  {
  }
}
