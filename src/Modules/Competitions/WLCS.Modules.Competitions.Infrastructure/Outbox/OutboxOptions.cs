// <copyright file="OutboxOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Outbox;

internal sealed class OutboxOptions
{
  public int IntervalInSeconds { get; init; }

  public int BatchSize { get; init; }
}
