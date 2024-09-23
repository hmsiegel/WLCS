// <copyright file="PlatformNameErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public static class PlatformNameErrors
{
  public static readonly Error Empty = Error.Problem(
    code: "PlatformName.Empty",
    description: "The meet name cannot be empty.");

  public static readonly Error Invalid = Error.Problem(
    code: "PlatformName.Invalid",
    description: "The meet name is invalid.");

  public static readonly Error TooLong = Error.Problem(
    code: "PlatformName.TooLong",
    description: "The meet name is too long.");
}
