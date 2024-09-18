// <copyright file="EmailLoggingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Logging;

public static class EmailLoggingExtensions
{
  private static readonly Action<ILogger, string, string, string, DateTime, Exception> _sendEmailLogger = InitializeAttemptingToSendEmailMessageLogger();
  private static readonly Action<ILogger, DateTime, Exception> _emailSentLogger = InitializeEmailSentLogger();

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

  public static void AttemptingToSendEmailMessage(this ILogger logger, string to, string from, string subject, DateTime time)
    => _sendEmailLogger(logger, to, from, subject, time, default!);

  public static void EmailSent(this ILogger logger, DateTime time)
    => _emailSentLogger(logger, time, default!);
}
