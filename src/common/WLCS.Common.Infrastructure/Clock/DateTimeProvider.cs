// <copyright file="DateTimeProvider.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Clock;

/// <summary>
/// Represents a provider of date and time.
/// </summary>
internal sealed class DateTimeProvider : IDateTimeProvider
{
  /// <inheritdoc/>
  public DateTime UtcNow => DateTime.UtcNow;

  /// <inheritdoc/>
  public DateOnly UtcDateNow => DateOnly.FromDateTime(DateTime.UtcNow);
}
