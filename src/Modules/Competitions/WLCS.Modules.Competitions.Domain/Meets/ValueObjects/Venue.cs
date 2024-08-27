// <copyright file="Venue.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.ValueObjects;

public sealed record Venue(string Value)
{
  public static Result<Venue> Create(string venue) =>
    Result.Ensure(
      venue,
      (name => !string.IsNullOrWhiteSpace(name), VenueErrors.Empty),
      (name => name.Length <= 100, VenueErrors.TooLong))
      .Map(name => new Venue(name));
}
