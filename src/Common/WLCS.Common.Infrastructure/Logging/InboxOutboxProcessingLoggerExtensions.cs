// <copyright file="InboxOutboxProcessingLoggerExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Logging;

public static class InboxOutboxProcessingLoggerExtensions
{
  private static readonly Action<ILogger, string, DateTime, Exception> _beginProcessOutboxMessages = InitializeBeginProcessOutboxMessageLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _completeProcessOutboxMessages = InitializeCompleteProcessOutboxMessageLogger();
  private static readonly Action<ILogger, string, Guid, Exception> _outboxMessageException = InitializeOutboxMessageExceptionLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _beginProcessInboxMessages = InitializeBeginProcessInboxMessageLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _completeProcessInboxMessages = InitializeCompleteProcessInboxMessageLogger();
  private static readonly Action<ILogger, string, Guid, Exception> _inboxMessageException = InitializeInboxMessageExceptionLogger();

  public static Action<ILogger, string, DateTime, Exception> InitializeBeginProcessOutboxMessageLogger()
  {
    return LoggerMessage.Define<string, DateTime>(
      LogLevel.Information,
      new EventId(7, nameof(BeginProcessingOutboxMessage)),
      "Beginning to process outbox messages for module {ModuleName} at {DateTime}");
  }

  public static Action<ILogger, string, DateTime, Exception> InitializeCompleteProcessOutboxMessageLogger()
  {
    return LoggerMessage.Define<string, DateTime>(
      LogLevel.Information,
      new EventId(8, nameof(CompleteProcessingInboxMessage)),
      "Finished processing outbox messages for module {ModuleName} at {DateTime}");
  }

  public static Action<ILogger, string, Guid, Exception> InitializeOutboxMessageExceptionLogger()
  {
    return LoggerMessage.Define<string, Guid>(
      LogLevel.Error,
      new EventId(9, nameof(OutboxMessageException)),
      "Error processing outbox message for module {ModuleName} on outbox message {MessageId}");
  }

  public static Action<ILogger, string, DateTime, Exception> InitializeBeginProcessInboxMessageLogger()
  {
    return LoggerMessage.Define<string, DateTime>(
      LogLevel.Information,
      new EventId(7, nameof(BeginProcessingInboxMessage)),
      "Beginning to process inbox messages for module {ModuleName} at {DateTime}");
  }

  public static Action<ILogger, string, DateTime, Exception> InitializeCompleteProcessInboxMessageLogger()
  {
    return LoggerMessage.Define<string, DateTime>(
      LogLevel.Information,
      new EventId(8, nameof(CompleteProcessingInboxMessage)),
      "Finished processing inbox messages for module {ModuleName} at {DateTime}");
  }

  public static Action<ILogger, string, Guid, Exception> InitializeInboxMessageExceptionLogger()
  {
    return LoggerMessage.Define<string, Guid>(
      LogLevel.Error,
      new EventId(9, nameof(InboxMessageException)),
      "Error processing inbox message for module {ModuleName} on inbox message {MessageId}");
  }

  public static void BeginProcessingOutboxMessage(this ILogger logger, string moduleName, DateTime time)
    => _beginProcessOutboxMessages(logger, moduleName, time, default!);

  public static void CompleteProcessingOutboxMessage(this ILogger logger, string moduleName, DateTime time)
    => _completeProcessOutboxMessages(logger, moduleName, time, default!);

  public static void OutboxMessageException(this ILogger logger, string moduleName, Guid id, Exception exception)
    => _outboxMessageException(logger, moduleName, id, exception);

  public static void BeginProcessingInboxMessage(this ILogger logger, string moduleName, DateTime time)
    => _beginProcessInboxMessages(logger, moduleName, time, default!);

  public static void CompleteProcessingInboxMessage(this ILogger logger, string moduleName, DateTime time)
    => _completeProcessInboxMessages(logger, moduleName, time, default!);

  public static void InboxMessageException(this ILogger logger, string moduleName, Guid id, Exception exception)
    => _inboxMessageException(logger, moduleName, id, exception);
}
