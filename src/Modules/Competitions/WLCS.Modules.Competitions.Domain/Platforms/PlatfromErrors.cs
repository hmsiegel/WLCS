// <copyright file="PlatfromErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public static class PlatfromErrors
{
  public static readonly Error NoPlatformsFound = Error.NotFound(
    "Platform.NoPlatformsFound",
    "No platforms found.");

  public static Error NotFound(Guid id) =>
    Error.NotFound(
    "Platform.NotFound",
    $"Platform with Id {id} was not found.");
}
