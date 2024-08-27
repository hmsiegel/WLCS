// <copyright file="LastName.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users.ValueObjects;

public sealed record LastName(string Value)
{
  public const int MaxLength = 200;

  public static Result<LastName> Create(string lastName) =>
    Result.Ensure(
      lastName,
      (lastName => !string.IsNullOrWhiteSpace(lastName), LastNameErrors.Empty),
      (lastName => lastName.Length <= MaxLength, LastNameErrors.Length))
      .Map(lastName => new LastName(lastName));
}
