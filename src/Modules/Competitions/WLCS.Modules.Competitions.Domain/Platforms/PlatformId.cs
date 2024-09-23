// <copyright file="PlatformId.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public sealed record PlatformId(Guid Value)
{
  public Guid Value { get; init; } = Value;

  public static PlatformId Create(Guid value) => new(value);

  public static PlatformId CreateUnique() => new(Guid.NewGuid());
}
