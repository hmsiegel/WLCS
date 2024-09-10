// <copyright file="LoggerExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Extensions;

public static class LoggerExtensions
{
  private static readonly Action<ILogger, string, DateTime, Exception> _processingRequst = InitializeRequestProcessingLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _completedRequest = InitializeRequestCompletedLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _beginProcessOutboxMessages = InitializeBeginProcessOutboxMessageLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _completeProcessOutboxMessages = InitializeCompleteProcessOutboxMessageLogger();
  private static readonly Action<ILogger, string, Guid, Exception> _outboxMessageException = InitializeOutboxMessageExceptionLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _beginProcessInboxMessages = InitializeBeginProcessInboxMessageLogger();
  private static readonly Action<ILogger, string, DateTime, Exception> _completeProcessInboxMessages = InitializeCompleteProcessInboxMessageLogger();
  private static readonly Action<ILogger, string, Guid, Exception> _inboxMessageException = InitializeInboxMessageExceptionLogger();
  private static readonly Action<ILogger, string, Error, Exception> _requestErrors = InitializeRequstErrorLogger();
  private static readonly Action<ILogger, string, Exception> _exceptionLogger = InitializeExceptionLogger();
  private static readonly Action<ILogger, string, Exception> _userRegistrationError = InitializeUserRegistrationError();
  private static readonly Action<ILogger, Exception> _globalException = InitializeGlobalExceptionLogger();

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

  public static Action<ILogger, string, Exception> InitializeExceptionLogger()
  {
    return LoggerMessage.Define<string>(
      LogLevel.Error,
      new EventId(4, nameof(Exception)),
      "Unhandled exception for {RequestName}");
  }

  public static Action<ILogger, string, Exception> InitializeUserRegistrationError()
  {
    return LoggerMessage.Define<string>(
      LogLevel.Error,
      new EventId(6, nameof(UserRegistrationError)),
      "User registration failed for {RequestName}");
  }

  public static Action<ILogger, Exception> InitializeGlobalExceptionLogger()
  {
    return LoggerMessage.Define(
      LogLevel.Critical,
      new EventId(5, nameof(Exception)),
      "Unhandled exception occurred");
  }

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

  public static void ProcessingRequest(this ILogger logger, string requestName, DateTime time)
    => _processingRequst(logger, requestName, time, default!);

  public static void CompletedRequest(this ILogger logger, string requestName, DateTime time)
    => _completedRequest(logger, requestName, time, default!);

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

  public static void RequestErrors(this ILogger logger, string requestName, Error error)
    => _requestErrors(logger, requestName, error, default!);

  public static void LogException(this ILogger logger, string requestName, Exception exception)
    => _exceptionLogger(logger, requestName, exception);

  public static void UserRegistrationError(this ILogger logger, string requestName, Exception exception)
    => _userRegistrationError(logger, requestName, exception);

  public static void LogGlobalException(this ILogger logger, Exception exception)
    => _globalException(logger, exception);
}
