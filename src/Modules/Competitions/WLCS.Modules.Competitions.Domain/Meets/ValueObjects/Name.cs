// <copyright file="Name.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.ValueObjects;

public sealed record Name(string Value)
{
  public static Result<Name> Create(string name) =>
    Result.Ensure(
      name,
      (name => !string.IsNullOrWhiteSpace(name), MeetNameErrors.Empty),
      (name => name.Length <= 100, MeetNameErrors.TooLong))
      .Map(name => new Name(name));
}
