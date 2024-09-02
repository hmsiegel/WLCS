// <copyright file="AthleteErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Athletes;

public static class AthleteErrors
{
  public static Error NotFound(Guid athleteId) => Error.NotFound(
    "Athlete.NotFound",
    $"User with id {athleteId} not found");

  public static Error NotFound(string identitiyId) => Error.NotFound(
    "Athlete.NotFound",
    $"User with id {identitiyId} not found");

  public static Error AthleteAlreadExists(string memberId) => Error.Conflict(
    "Athlete.AthleteAlreadyExists",
    $"The athlete with the membership ID {memberId} is already registered.");
}
