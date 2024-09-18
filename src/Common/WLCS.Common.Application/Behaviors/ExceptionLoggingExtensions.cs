// <copyright file="ExceptionLoggingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

public static class ExceptionLoggingExtensions
{
  private static readonly Action<ILogger, string, Exception> _exceptionLogger = InitializeExceptionLogger();

  public static Action<ILogger, string, Exception> InitializeExceptionLogger()
  {
    return LoggerMessage.Define<string>(
      LogLevel.Error,
      new EventId(4, nameof(Exception)),
      "Unhandled exception for {RequestName}");
  }

  public static void LogException(this ILogger logger, string requestName, Exception exception)
    => _exceptionLogger(logger, requestName, exception);
}
