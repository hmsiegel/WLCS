// <copyright file="ProcessOutboxJob.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxJob(
  IDbConnectionFactory dbConnectionFactory,
  IServiceScopeFactory serviceScopeFactory,
  IDateTimeProvider dateTimeProvider,
  IOptions<OutboxOptions> options,
  ILogger<ProcessOutboxJob> logger) : IJob
{
  private const string ModuleName = "Administration";

  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
  private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
  private readonly OutboxOptions _options = options.Value;
  private readonly ILogger<ProcessOutboxJob> _logger = logger;

  public async Task Execute(IJobExecutionContext context)
  {
    LoggerExtensions.BeginProcessingOutboxMessage(
      _logger,
      ModuleName,
      _dateTimeProvider.UtcNow);

    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();
    await using var transaction = await connection.BeginTransactionAsync();

    var outboxMessages = await GetOutboxMessagesAsync(connection, transaction);

    foreach (var outboxMessage in outboxMessages)
    {
      Exception? exception = null;
      try
      {
        var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
          outboxMessage.Content,
          SerializerSettings.Instance)!;

        using var scope = _serviceScopeFactory.CreateScope();

        var domainEventHandlers = DomainEventHandlersFactory.GetHandlers(
          domainEvent.GetType(),
          scope.ServiceProvider,
          Application.AssemblyReference.Assembly);

        foreach (var domainEventHandler in domainEventHandlers)
        {
          await domainEventHandler.Handle(domainEvent);
        }
      }
      catch (Exception caughtException)
      {
        LoggerExtensions.OutboxMessageException(
          _logger,
          ModuleName,
          outboxMessage.Id,
          caughtException);

        exception = caughtException;
      }

      // HACK: Add logic to continue to retry messages if they fail
      await UpdateOutboxMessageAsync(connection, transaction, outboxMessage, exception);
    }

    await transaction.CommitAsync();

    LoggerExtensions.CompleteProcessingOutBoxMessage(
      _logger,
      ModuleName,
      _dateTimeProvider.UtcNow);
  }

  private async Task<IReadOnlyList<OutboxMessageResponse>> GetOutboxMessagesAsync(
    IDbConnection connection,
    IDbTransaction transaction)
  {
    string sql =
      $"""
      SELECT
        id AS {nameof(OutboxMessageResponse.Id)},
        content AS {nameof(OutboxMessageResponse.Content)}
      FROM administration.outbox_messages
      WHERE processed_on_utc IS NULL
      ORDER BY occurred_on_utc
      LIMIT {_options.BatchSize}
      FOR UPDATE SKIP LOCKED
      """;

    var outboxMessages = await connection.QueryAsync<OutboxMessageResponse>(
      sql,
      transaction: transaction);

    return outboxMessages.ToList();
  }

  private async Task UpdateOutboxMessageAsync(
    IDbConnection connection,
    IDbTransaction transaction,
    OutboxMessageResponse outboxMessage,
    Exception? exception)
  {
    string sql =
      $"""
      UPDATE administration.outbox_messages
      SET processed_on_utc = @ProcessedOnUtc,
        error = @Error
      WHERE id = @Id
      """;

    await connection.ExecuteAsync(
      sql,
      new
      {
        outboxMessage.Id,
        ProcessedOnUtc = _dateTimeProvider.UtcNow,
        Error = exception?.ToString(),
      },
      transaction: transaction);
  }

  internal sealed record OutboxMessageResponse(Guid Id, string Content);
}
