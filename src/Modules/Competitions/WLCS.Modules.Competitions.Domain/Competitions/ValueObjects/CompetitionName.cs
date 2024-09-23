// <copyright file="CompetitionName.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions.ValueObjects;

public sealed record CompetitionName(string Value)
{
  public static Result<CompetitionName> Create(string name) =>
    Result.Ensure(
      name,
      (name => !string.IsNullOrWhiteSpace(name), MeetNameErrors.Empty),
      (name => name.Length <= 100, MeetNameErrors.TooLong))
      .Map(name => new CompetitionName(name));
}
