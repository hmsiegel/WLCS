namespace Modules.Users.Infrastructure.Idempotence;

/// <summary>
/// Represents the integration event consumer.
/// </summary>
/// <typeparam name="TIntegrationEvent">The integration event type.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="IntegrationEventConsumer{TIntegrationEvent}"/> class.
/// </remarks>
/// <param name="sqlQueryExecutor">The SQL query executor.</param>
internal sealed class IntegrationEventConsumer<TIntegrationEvent>(ISqlQueryExecutor sqlQueryExecutor)
    : IConsumer<TIntegrationEvent>
    where TIntegrationEvent : class, IIntegrationEvent
{
    /// <inheritdoc/>
    public async Task Consume(ConsumeContext<TIntegrationEvent> context)
    {
        var integrationEvent = context.Message;

        var inboxMessage = new InboxMessage(
            integrationEvent.Id,
            integrationEvent.OccurredOnUtc,
            integrationEvent.GetType().Name,
            JsonConvert.SerializeObject(
                integrationEvent,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                }));

        const string insertInboxMessageSql = @"
            INSERT INTO users.inbox_messages (id, occurred_on_utc, type, data)
            VALUES (@Id, @OccurredOnUtc, @Type, @Content::json);";

        await sqlQueryExecutor.ExecuteAsync(insertInboxMessageSql, inboxMessage).ConfigureAwait(false);
    }
}
