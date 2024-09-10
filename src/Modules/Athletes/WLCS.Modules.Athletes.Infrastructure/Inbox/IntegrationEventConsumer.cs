// <copyright file="IntegrationEventConsumer.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Inbox;

internal sealed class IntegrationEventConsumer<TIntegrationEvent>(IDbConnectionFactory dbConnectionFactory)
  : IConsumer<TIntegrationEvent>
  where TIntegrationEvent : IntegrationEvent
{
  private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;

  public async Task Consume(ConsumeContext<TIntegrationEvent> context)
  {
    await using var connection = await _dbConnectionFactory.OpenConnectionAsync();

    TIntegrationEvent integrationEvent = context.Message;

    var inboxMessage = new InboxMessage
    {
      Id = integrationEvent.Id,
      Type = integrationEvent.GetType().Name,
      Content = JsonConvert.SerializeObject(integrationEvent, SerializerSettings.Instance),
      OccurredOnUtc = integrationEvent.OccurredOnUtc,
    };

    const string sql =
      """
      INSERT INTO athletes.inbox_messages (id, type, content, occurred_on_utc)
      VALUES (@Id, @Type, @Content::json, @OccurredOnUtc);
      """;

    await connection.ExecuteAsync(sql, inboxMessage);
  }
}
