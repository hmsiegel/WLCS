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

  public static readonly Error AthleteAlreadyAdded = Error.Conflict(
    code: "Meets.AthleteAlreadyAdded",
    description: "The athlete has already been added to the meet.");

  public static readonly Error PlatformAlreadyAdded = Error.Conflict(
    code: "Meets.PlatformAlreadyAdded",
    description: "The platform has already been added to the meet.");

  public static Error CompetitionNotFound(Guid competitionId) =>
    Error.NotFound(
      code: "Meets.CompetitionNotFound",
      description: $"Competition with id {competitionId} was not found.");

  public static Error AthleteNotFound(Guid athleteId) =>
    Error.NotFound(
      code: "Meets.AthleteNotFound",
      description: $"Athlete with id {athleteId} was not found.");

  public static Error PlatformNotFound(Guid platformId) =>
    Error.NotFound(
      code: "Meets.PlatformNotFound",
      description: $"Platform with id {platformId} was not found.");

  public static Error NotFound(Guid id) =>
    Error.NotFound(
      code: "Meets.NotFound",
      description: $"Meet with id {id} was not found.");
}
