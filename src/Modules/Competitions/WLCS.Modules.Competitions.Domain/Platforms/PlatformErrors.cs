// <copyright file="PlatformErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public static class PlatformErrors
{
  public static readonly Error CompetitionAlreadyExists = Error.Conflict(
    code: "Platforms.CompetitionAlreadyExists",
    description: "The competition is already being used.");

  public static readonly Error NoPlatformsFound = Error.NotFound(
    "Platforms.NoPlatformsFound",
    "No platforms found.");

  public static Error NotFound(Guid id) =>
    Error.NotFound(
    "Platforms.NotFound",
    $"Platform with Id {id} was not found.");

  public static Error CompetitionNotFound(Guid competitionId) =>
    Error.NotFound(
      code: "Platforms.CompetitionNotFound",
      description: $"Competition with id {competitionId} was not found.");
}
