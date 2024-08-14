// <copyright file="DateTimeProvider.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
  public DateTime UtcNow => DateTime.UtcNow;

  public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}
