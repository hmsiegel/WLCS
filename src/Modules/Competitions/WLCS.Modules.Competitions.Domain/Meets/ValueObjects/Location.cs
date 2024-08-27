// <copyright file="Location.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.ValueObjects;

public sealed record Location(string City, string State)
{
  public static Result<Location> Create(string city, string state)
  {
    if (string.IsNullOrWhiteSpace(city))
    {
      return Result.Failure<Location>(LocationErrors.CityIsRequired);
    }

    if (string.IsNullOrWhiteSpace(state))
    {
      return Result.Failure<Location>(LocationErrors.StateIsRequired);
    }

    return Result.Success(new Location(city, state));
  }
}
