// <copyright file="Email.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.ValueObjects;

public sealed record Email(string Value)
{
  public static Result<Email> Create(string? email) =>
    Result.Ensure(
       email,
       (e => !string.IsNullOrWhiteSpace(e), EmailErrors.Empty),
       (e => e!.Length <= 256, EmailErrors.TooLong),
       (e => e!.Contains('@', StringComparison.InvariantCulture), EmailErrors.InvalidFormat))
    .Map(e => new Email(e!));
}
