// <copyright file="IDateTimeProvider.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Clock;

public interface IDateTimeProvider
{
  public DateTime UtcNow { get; }

  public DateOnly Today { get; }
}
