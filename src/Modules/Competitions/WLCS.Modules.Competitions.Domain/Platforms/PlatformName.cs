// <copyright file="PlatformName.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public sealed record PlatformName(string Value)
{
  public static int MaxLength => 100;

  public static Result<PlatformName> Create(string name) =>
    Result.Ensure(
      name,
      (name => !string.IsNullOrWhiteSpace(name), PlatformNameErrors.Empty),
      (name => name.Length <= 100, PlatformNameErrors.TooLong))
      .Map(name => new PlatformName(name));
}
