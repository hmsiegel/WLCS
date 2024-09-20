// <copyright file="EmailLoggingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Logging;

public static class EmailLoggingExtensions
{
  private static readonly Action<ILogger, string, string, string, DateTime, Exception> _sendEmailLogger = InitializeAttemptingToSendEmailMessageLogger();
  private static readonly Action<ILogger, DateTime, Exception> _emailSentLogger = InitializeEmailSentLogger();
  private static readonly Action<ILogger, string, Exception> _backgroundServiceLogger = InitializeBackgroundServiceLogger();
  private static readonly Action<ILogger, string, Exception> _backgroundServiceExceptionLogger = InitializeBackgroundServiceExceptionLogger();
  private static readonly Action<ILogger, long, Exception> _emailOutboxProcessedLogger = InitializeEmailOutboxProcessedLogger();
  private static readonly Action<ILogger, Exception> _sleepingEmailProcessedLogger = InitializeSleepingEmailProcessedLogger();

  public static Action<ILogger, DateTime, Exception> InitializeEmailSentLogger()
  {
    return LoggerMessage.Define<DateTime>(
      LogLevel.Information,
      new EventId(2, nameof(EmailSent)),
      "Email sent at {DateTime}");
  }

  public static Action<ILogger, string, string, string, DateTime, Exception> InitializeAttemptingToSendEmailMessageLogger()
  {
    return LoggerMessage.Define<string, string, string, DateTime>(
      LogLevel.Information,
      new EventId(1, nameof(AttemptingToSendEmailMessage)),
      "Attempting to send email to {To} from {From} with subject {Subject} at {DateTime}");
  }

  public static Action<ILogger, string, Exception> InitializeBackgroundServiceLogger()
  {
    return LoggerMessage.Define<string>(
      LogLevel.Information,
      new EventId(3, nameof(BackgroundServiceStarting)),
      "{ServiceName} starting...");
  }

  public static Action<ILogger, string, Exception> InitializeBackgroundServiceExceptionLogger()
  {
    return LoggerMessage.Define<string>(
      LogLevel.Error,
      new EventId(4, nameof(BackgroundServiceException)),
      "Error processing outbox message: {Message}");
  }

  public static Action<ILogger, long, Exception> InitializeEmailOutboxProcessedLogger()
  {
    return LoggerMessage.Define<long>(
      LogLevel.Information,
      new EventId(5, nameof(EmailOutboxProcessed)),
      "{Count} email outbox messages processed");
  }

  public static Action<ILogger, Exception> InitializeSleepingEmailProcessedLogger()
  {
    return LoggerMessage.Define(
      LogLevel.Information,
      new EventId(6, nameof(Sleeping)),
      "Sleeping...");
  }

  public static void AttemptingToSendEmailMessage(this ILogger logger, string to, string from, string subject, DateTime time)
    => _sendEmailLogger(logger, to, from, subject, time, default!);

  public static void EmailSent(this ILogger logger, DateTime time)
    => _emailSentLogger(logger, time, default!);

  public static void BackgroundServiceStarting(this ILogger logger, string serviceName)
    => _backgroundServiceLogger(logger, serviceName, default!);

  public static void BackgroundServiceException(this ILogger logger, string message, Exception ex)
    => _backgroundServiceExceptionLogger(logger, message, ex);

  public static void EmailOutboxProcessed(this ILogger logger, long count)
    => _emailOutboxProcessedLogger(logger, count, default!);

  public static void Sleeping(this ILogger logger)
    => _sleepingEmailProcessedLogger(logger, default!);
}
