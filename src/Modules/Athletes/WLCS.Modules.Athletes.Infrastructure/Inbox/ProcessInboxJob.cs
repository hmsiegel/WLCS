// <copyright file="ProcessInboxJob.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Inbox;

[DisallowConcurrentExecution]
internal sealed class ProcessInboxJob(
  IDbConnectionFactory dbConnectionFactory,
  IServiceScopeFactory serviceScopeFactory,
  IDateTimeProvider dateTimeProvider,
  IOptions<InboxOptions> options,
  ILogger<ProcessInboxJob> logger) : IJob
{
  private const string ModuleName = "Athletes";

  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
  private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
  private readonly InboxOptions _options = options.Value;
  private readonly ILogger<ProcessInboxJob> _logger = logger;

  public async Task Execute(IJobExecutionContext context)
  {
    InboxOutboxProcessingLoggerExtensions.BeginProcessingInboxMessage(
      _logger,
      ModuleName,
      _dateTimeProvider.UtcNow);

    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();
    await using var transaction = await connection.BeginTransactionAsync();

    var inboxMessages = await GetInboxMessagesAsync(connection, transaction);

    foreach (var inboxMessage in inboxMessages)
    {
      Exception? exception = null;
      try
      {
        var integrationEvent = JsonConvert.DeserializeObject<IIntegrationEvent>(
          inboxMessage.Content,
          SerializerSettings.Instance)!;

        using var scope = _serviceScopeFactory.CreateScope();

        var integrationEventHandlers = IntgrationEventHandlersFactory.GetHandlers(
          integrationEvent.GetType(),
          scope.ServiceProvider,
          Presentation.AssemblyReference.Assembly);

        foreach (var integrationEventHandler in integrationEventHandlers)
        {
          await integrationEventHandler.Handle(integrationEvent);
        }
      }
      catch (Exception caughtException)
      {
        InboxOutboxProcessingLoggerExtensions.InboxMessageException(
          _logger,
          ModuleName,
          inboxMessage.Id,
          caughtException);

        exception = caughtException;
      }

      // HACK: Add logic to continue to retry messages if they fail
      await UpdateInboxMessageAsync(connection, transaction, inboxMessage, exception);
    }

    await transaction.CommitAsync();

    InboxOutboxProcessingLoggerExtensions.CompleteProcessingInboxMessage(
      _logger,
      ModuleName,
      _dateTimeProvider.UtcNow);
  }

  private async Task<IReadOnlyList<InboxMessageResponse>> GetInboxMessagesAsync(
    IDbConnection connection,
    IDbTransaction transaction)
  {
    string sql =
      $"""
      SELECT
        id AS {nameof(InboxMessageResponse.Id)},
        content AS {nameof(InboxMessageResponse.Content)}
      FROM athletes.inbox_messages
      WHERE processed_on_utc IS NULL
      ORDER BY occurred_on_utc
      LIMIT {_options.BatchSize}
      FOR UPDATE SKIP LOCKED
      """;

    var inboxMessages = await connection.QueryAsync<InboxMessageResponse>(
      sql,
      transaction: transaction);

    return inboxMessages.ToList();
  }

  private async Task UpdateInboxMessageAsync(
    IDbConnection connection,
    IDbTransaction transaction,
    InboxMessageResponse inboxMessage,
    Exception? exception)
  {
    string sql =
      $"""
      UPDATE athletes.inbox_messages
      SET processed_on_utc = @ProcessedOnUtc,
        error = @Error
      WHERE id = @Id
      """;

    await connection.ExecuteAsync(
      sql,
      new
      {
        inboxMessage.Id,
        ProcessedOnUtc = _dateTimeProvider.UtcNow,
        Error = exception?.ToString(),
      },
      transaction: transaction);
  }

  internal sealed record InboxMessageResponse(Guid Id, string Content);
}
