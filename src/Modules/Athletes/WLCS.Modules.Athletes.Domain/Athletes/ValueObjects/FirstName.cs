// <copyright file="FirstName.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.ValueObjects;

public sealed record FirstName(string Value)
{
  public const int MaxLength = 200;

  public static Result<FirstName> Create(string firstName) =>
    Result.Create(firstName)
      .Ensure(
      firstName => !string.IsNullOrWhiteSpace(firstName), FirstNameErrors.Empty)
      .Ensure(
        firstName => firstName.Length <= MaxLength, FirstNameErrors.Length)
      .Map(firstName => new FirstName(firstName));
}
