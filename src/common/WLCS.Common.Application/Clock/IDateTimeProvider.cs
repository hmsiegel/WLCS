// <copyright file="IDateTimeProvider.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Clock;

/// <summary>
/// Represents a provider of the current date and time.
/// </summary>
public interface IDateTimeProvider
{
  /// <summary>
  /// Gets the current date and time in UTC.
  /// </summary>
  public DateTime UtcNow { get; }

  /// <summary>
  /// Gets the current date in UTC.
  /// </summary>
  public DateOnly UtcDateNow { get; }
}
