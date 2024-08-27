// <copyright file="MeetId.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.ValueObjects;

public sealed record MeetId(Guid Value)
{
  public Guid Value { get; init; } = Value;

  public static MeetId Create(Guid value) => new(value);

  public static MeetId CreateUnique() => new(Guid.NewGuid());
}
