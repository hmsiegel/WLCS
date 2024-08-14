// <copyright file="LoggerExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Extensions;

internal static class LoggerExtensions
{
  private static readonly Action<ILogger, string, DateTime, Exception> _processingRequst = InitializeRequestProcessingLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _completedRequest = InitializeRequestCompletedLogger();
  private static readonly Action<ILogger, string, Error, Exception> _requestErrors = InitializeRequstErrorLogger();

  public static Action<ILogger, string, DateTime, Exception> InitializeRequestProcessingLogger()
  {
    return LoggerMessage.Define<string, DateTime>(
      LogLevel.Information,
      new EventId(1, nameof(ProcessingRequest)),
      "Processing request {RequstName} at {DateTime}");
  }

  public static Action<ILogger, string, DateTime, Exception> InitializeRequestCompletedLogger()
  {
    return LoggerMessage.Define<string, DateTime>(
      LogLevel.Information,
      new EventId(2, nameof(CompletedRequest)),
      "Completed request {RequstName} at {DateTime}");
  }

  public static Action<ILogger, string, Error, Exception> InitializeRequstErrorLogger()
  {
    return LoggerMessage.Define<string, Error>(
      LogLevel.Error,
      new EventId(3, nameof(RequestErrors)),
      "Completed request {RequstName} with error {Error}");
  }

  public static void ProcessingRequest(this ILogger logger, string requestName, DateTime time)
    => _processingRequst(logger, requestName, time, default!);

  public static void CompletedRequest(this ILogger logger, string requestName, DateTime time)
    => _completedRequest(logger, requestName, time, default!);

  public static void RequestErrors(this ILogger logger, string requestName, Error error)
    => _requestErrors(logger, requestName, error, default!);
}
