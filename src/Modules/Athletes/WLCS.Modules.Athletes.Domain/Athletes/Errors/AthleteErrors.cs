// <copyright file="AthleteErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.Errors;

public static class AthleteErrors
{
  public static Error EmailAlreadyInUse => Error.Conflict(
    "Athlete.EmailAlreadyInUse",
    "Email is already in use");

  public static Error NotFoud(Guid userId) => Error.NotFound(
    "Athlete.NotFound",
    $"User with id {userId} not found");

  public static Error NotFoud(string identitiyId) => Error.NotFound(
    "Athlete.NotFound",
    $"User with id {identitiyId} not found");

  public static Error AthleteAlreadExists(string memberId) => Error.Conflict(
    "Athlete.AthleteAlreadyExists",
    $"The athlete with the membership ID {memberId} is already registered.");
}
