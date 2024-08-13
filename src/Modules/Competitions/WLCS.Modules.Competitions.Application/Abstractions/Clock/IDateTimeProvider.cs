// <copyright file="IDateTimeProvider.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
  public DateTime UtcNow { get; }

  public DateOnly Today { get; }
}
