// <copyright file="Poller.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Abstractions;

/// <summary>
/// A helper class to poll a function until it returns a successful result or the timeout is reached.
/// </summary>
internal static class Poller
{
  private static readonly Error _timeout = Error.Failure(
    "Poller.Timeout",
    "The poller timed out while waiting for the condition to be met.");

  /// <summary>
  /// Helper method to poll a function until it returns a successful result or the timeout is reached.
  /// </summary>
  /// <typeparam name="T">The type that we are returning.</typeparam>
  /// <param name="timeout">The length of time before the polling times out.</param>
  /// <param name="func">The functions that gets the result.</param>
  /// <returns>The type.</returns>
  internal static async Task<Result<T>> WaitAsync<T>(TimeSpan timeout, Func<Task<Result<T>>> func)
  {
    using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

    var endTimeUtc = DateTime.UtcNow.Add(timeout);

    while (DateTime.UtcNow < endTimeUtc && await timer.WaitForNextTickAsync())
    {
      var result = await func();

      if (result.IsSuccess)
      {
        return result;
      }
    }

    return Result.Failure<T>(_timeout);
  }
}
