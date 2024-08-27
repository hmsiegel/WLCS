// <copyright file="VenueErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.Errors;

public static class VenueErrors
{
  public static readonly Error Empty = Error.Problem(
    code: "Venue.Empty",
    description: "The meet name cannot be empty.");

  public static readonly Error Invalid = Error.Problem(
    code: "Venue.Invalid",
    description: "The meet name is invalid.");

  public static readonly Error TooLong = Error.Problem(
    code: "Venue.TooLong",
    description: "The meet name is too long.");
}
