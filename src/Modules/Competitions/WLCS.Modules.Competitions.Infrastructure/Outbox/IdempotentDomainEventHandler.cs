// <copyright file="IdempotentDomainEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Outbox;

internal sealed class IdempotentDomainEventHandler<TDomainEvent>(
  IDomainEventHandler<TDomainEvent> decorated,
  IDbConnectionFactory dbConnectionFactory)
  : DomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
  private readonly IDomainEventHandler<TDomainEvent> _decorated = decorated;
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public override async Task Handle(
    TDomainEvent domainEvent,
    CancellationToken cancellationToken = default)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    var outBoxMessageConsumer = new OutboxMessageConsumer(
      domainEvent.Id,
      _decorated.GetType().Name);

    if (await OutboxMessageConsumerExistsAsync(connection, outBoxMessageConsumer))
    {
      return;
    }

    await _decorated.Handle(domainEvent, cancellationToken);

    await InsertOutboxConsumerAsync(connection, outBoxMessageConsumer);
  }

  private static async Task<bool> OutboxMessageConsumerExistsAsync(
    DbConnection connection,
    OutboxMessageConsumer outBoxMessageConsumer)
  {
    const string sql =
      """
      SELECT EXISTS(
        SELECT 1
        FROM competitions.outbox_message_consumers
        WHERE outbox_message_id = @OutboxMessageId
          AND name = @Name
      )
      """;

    return await connection.ExecuteScalarAsync<bool>(sql, outBoxMessageConsumer);
  }

  private static async Task InsertOutboxConsumerAsync(
    DbConnection connection,
    OutboxMessageConsumer outBoxMessageConsumer)
  {
    const string sql =
      """
      INSERT INTO competitions.outbox_message_consumers(outbox_message_id, name)
      VALUES (@OutboxMessageId, @Name);
      """;

    await connection.ExecuteAsync(sql, outBoxMessageConsumer);
  }
}
