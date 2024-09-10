// <copyright file="InboxOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Inbox;

internal sealed class InboxOptions
{
  public int IntervalInSeconds { get; init; }

  public int BatchSize { get; init; }
}
