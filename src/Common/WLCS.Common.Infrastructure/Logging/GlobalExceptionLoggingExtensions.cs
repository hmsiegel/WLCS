﻿// <copyright file="GlobalExceptionLoggingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Logging;

public static class GlobalExceptionLoggingExtensions
{
  private static readonly Action<ILogger, Exception> _globalException = InitializeGlobalExceptionLogger();

  public static Action<ILogger, Exception> InitializeGlobalExceptionLogger()
  {
    return LoggerMessage.Define(
      LogLevel.Critical,
      new EventId(5, nameof(Exception)),
      "Unhandled exception occurred");
  }

  public static void LogGlobalException(this ILogger logger, Exception exception)
    => _globalException(logger, exception);
}
