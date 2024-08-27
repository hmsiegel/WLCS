// <copyright file="AthleteId.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.ValueObjects;

public sealed record AthleteId(Guid Value)
{
  public Guid Value { get; init; } = Value;

  public static AthleteId Create(Guid value) => new(value);

  public static AthleteId CreateUnique() => new(Guid.NewGuid());
}
