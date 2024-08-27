// <copyright file="CompetitionId.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions.ValueObjects;

public sealed record CompetitionId(Guid Value)
{
  public Guid Value { get; init; } = Value;

  public static CompetitionId Create(Guid value) => new(value);

  public static CompetitionId CreateUnique() => new(Guid.NewGuid());
}
