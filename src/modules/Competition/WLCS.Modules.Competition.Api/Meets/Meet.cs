// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Api.Meets;

/// <summary>
/// Represents a meet.
/// </summary>
public sealed class Meet
{
  /// <summary>
  /// Gets or sets the unique identifier of the meet.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Gets or sets the name of the meet.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the start date of the meet.
  /// </summary>
  public DateOnly StartDate { get; set; }

  /// <summary>
  /// Gets or sets the end date of the meet.
  /// </summary>
  public DateOnly EndDate { get; set; }

  /// <summary>
  /// Gets or sets the location of the meet.
  /// </summary>
  public string Location { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the venue of the meet.
  /// </summary>
  public string Venue { get; set; } = string.Empty;
}
