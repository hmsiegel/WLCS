// <copyright file="LocationErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.Errors;

public static class LocationErrors
{
  public static readonly Error Empty = Error.Problem(
    code: "Location.Empty",
    description: "The meet name cannot be empty.");

  public static readonly Error Invalid = Error.Problem(
    code: "Location.Invalid",
    description: "The meet name is invalid.");

  public static readonly Error TooLong = Error.Problem(
    code: "Location.TooLong",
    description: "The meet name is too long.");

  public static readonly Error CityIsRequired = Error.Problem(
    code: "Location.CityIsRequired",
    description: "A city is required.");

  public static readonly Error StateIsRequired = Error.Problem(
    code: "Location.StateIsRequired",
    description: "A state is required.");
}
