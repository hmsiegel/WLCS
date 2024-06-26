﻿// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Domain.Meets;

/// <summary>
/// Represents a meet.
/// </summary>
public sealed class Meet : Entity
{
  private Meet(
    string name,
    LocalDate startDate,
    LocalDate endDate,
    string location,
    string venue,
    Guid? id = null)
  {
    Id = id ?? Guid.NewGuid();
    Name = name;
    StartDate = startDate;
    EndDate = endDate;
    Location = location;
    Venue = venue;
  }

  private Meet()
  {
  }

  /// <summary>
  /// Gets the unique identifier of the meet.
  /// </summary>
  public Guid Id { get; private set; }

  /// <summary>
  /// Gets the name of the meet.
  /// </summary>
  public string Name { get; private set; } = string.Empty;

  /// <summary>
  /// Gets the start date of the meet.
  /// </summary>
  public LocalDate StartDate { get; private set; }

  /// <summary>
  /// Gets the end date of the meet.
  /// </summary>
  public LocalDate EndDate { get; private set; }

  /// <summary>
  /// Gets the location of the meet.
  /// </summary>
  public string Location { get; private set; } = string.Empty;

  /// <summary>
  /// Gets the venue of the meet.
  /// </summary>
  public string Venue { get; private set; } = string.Empty;

  /// <summary>
  /// Creates a new meet.
  /// </summary>
  /// <param name="name">The name of the meet.</param>
  /// <param name="location">The city and state that the meet takes place in.</param>
  /// <param name="venue">The venue of the meet.</param>
  /// <param name="startDate">The first date of the meet in local time.</param>
  /// <param name="endDate">The last date of the meet in local time.</param>
  /// <returns>A new meet.</returns>
  public static Result<Meet> Create(
    string name,
    string location,
    string venue,
    LocalDate startDate,
    LocalDate endDate)
  {
    if (endDate < startDate)
    {
      return Result.Failure<Meet>(MeetErrors.EndDatePrecedesStartDate);
    }

    var meet = new Meet(
      name,
      startDate,
      endDate,
      location,
      venue);

    meet.Raise(new MeetCreatedDomainEvent(meet.Id));

    return meet;
  }
}
