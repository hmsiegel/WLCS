// <copyright file="MeetErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.Errors;

public static class MeetErrors
{
  public static readonly Error StartDateIsInThePast = Error.Problem(
    code: "Meets.StartDateIsInThePast",
    description: "Start date cannot be in the past.");

  public static readonly Error EndDatePrecedesStartDate = Error.Problem(
    code: "Meets.EndDatePrecedesStartDate",
    description: "The meet end date precedes the start date.");

  public static readonly Error AlreadyArchived = Error.Problem(
    code: "Meets.AlreadyArchived",
    description: "The meet is already archived.");

  public static readonly Error CompetitionAlreadyAdded = Error.Conflict(
    code: "Meets.CompetitionAlreadyAdded",
    description: "The competition has already been added to the meet.");

  public static Error NotFound(Guid id) =>
    Error.NotFound(
      code: "Meets.NotFound",
      description: $"Meet with id {id} was not found.");
}
