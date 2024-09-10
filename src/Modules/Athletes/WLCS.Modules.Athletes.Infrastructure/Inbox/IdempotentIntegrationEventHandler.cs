// <copyright file="IdempotentIntegrationEventHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Inbox;

internal sealed class IdempotentIntegrationEventHandler<TIntegrationEvent>(
  IIntegrationEventHandler<TIntegrationEvent> decorated,
  IDbConnectionFactory dbConnectionFactory)
  : IntegrationEventHandler<TIntegrationEvent>
    where TIntegrationEvent : IIntegrationEvent
{
  private readonly IIntegrationEventHandler<TIntegrationEvent> _decorated = decorated;
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public override async Task Handle(
    TIntegrationEvent integrationEvent,
    CancellationToken cancellationToken = default)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    var inboxMessageConsumer = new InboxMessageConsumer(
      integrationEvent.Id,
      _decorated.GetType().Name);

    if (await InboxConsumerExistsAsync(connection, inboxMessageConsumer))
    {
      return;
    }

    await _decorated.Handle(integrationEvent, cancellationToken);

    await InsertInboxConsumerAsync(connection, inboxMessageConsumer);
  }

  private static async Task<bool> InboxConsumerExistsAsync(
    DbConnection connection,
    InboxMessageConsumer inboxMessageConsumer)
  {
    const string sql =
      """
      SELECT EXISTS(
        SELECT 1
        FROM athletes.inbox_message_consumers
        WHERE inbox_message_id = @InboxMessageId
          AND name = @Name
      )
      """;

    return await connection.ExecuteScalarAsync<bool>(sql, inboxMessageConsumer);
  }

  private static async Task InsertInboxConsumerAsync(
    DbConnection connection,
    InboxMessageConsumer inboxMessageConsumer)
  {
    const string sql =
      """
      INSERT INTO athletes.inbox_message_consumers(inbox_message_id, name)
      VALUES (@InboxMessageId, @Name);
      """;

    await connection.ExecuteAsync(sql, inboxMessageConsumer);
  }
}
