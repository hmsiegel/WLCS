﻿// <copyright file="Poller.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.Abstractions;

internal static class Poller
{
  private static readonly Error _timeout = Error.Failure(
    "Poller.Timeout",
    "The poller has timed out.");

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
