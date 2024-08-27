// <copyright file="LastName.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.ValueObjects;

public sealed record LastName(string Value)
{
  public const int MaxLength = 200;

  public static Result<LastName> Create(string lastName) =>
    Result.Create(lastName)
      .Ensure(
      lastName => !string.IsNullOrWhiteSpace(lastName), LastNameErrors.Empty)
      .Ensure(
        lastName => lastName.Length <= MaxLength, LastNameErrors.Length)
      .Map(lastName => new LastName(lastName));
}
