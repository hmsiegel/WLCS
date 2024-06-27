// <copyright file="MeetErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Domain.Meets;

/// <summary>
/// Errors for the meet object.
/// </summary>
public static class MeetErrors
{
  /// <summary>
  /// Represents an error indicating that the end date precedes the start date.
  /// </summary>
  public static readonly Error EndDatePrecedesStartDate =
    Error.Problem(
      "Meets.EndDatePrecedesStartDate",
      "The meet end date precedes the start date.");

  /// <summary>
  /// Represents an error indicating that the meet was not found.
  /// </summary>
  public static readonly Error MeetNotFound =
    Error.NotFound(
      "Meets.MeetNotFound",
      "The meet was not found.");
}
