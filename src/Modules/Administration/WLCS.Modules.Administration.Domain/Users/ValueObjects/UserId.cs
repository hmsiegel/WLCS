// <copyright file="UserId.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users.ValueObjects;

public sealed record UserId(Guid Value)
{
  public Guid Value { get; init; } = Value;

  public static UserId Create(Guid value) => new(value);

  public static UserId CreateUnique() => new(Guid.NewGuid());
}
