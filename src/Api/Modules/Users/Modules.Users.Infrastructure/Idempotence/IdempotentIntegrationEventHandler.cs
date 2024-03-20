namespace Modules.Users.Infrastructure.Idempotence;

/// <summary>
/// Represents the idempotent integration event handler, which checks if the integration event has already been handled previously.
/// </summary>
/// <typeparam name="TIntegrationEvent">The integration event type.</typeparam>
internal sealed class IdempotentIntegrationEventHandler<TIntegrationEvent> : IntegrationEventHandler<TIntegrationEvent>
    where TIntegrationEvent : IIntegrationEvent
{
    private readonly IIntegrationEventHandler<TIntegrationEvent> _decorated;
    private readonly ISqlQueryExecutor _sqlQueryExecutor;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdempotentIntegrationEventHandler{TEvent}"/> class.
    /// </summary>
    /// <param name="decorated">The decorated integration event handler.</param>
    /// <param name="sqlQueryExecutor">The SQL query executor.</param>
    public IdempotentIntegrationEventHandler(IIntegrationEventHandler<TIntegrationEvent> decorated, ISqlQueryExecutor sqlQueryExecutor)
    {
        _decorated = decorated;
        _sqlQueryExecutor = sqlQueryExecutor;
    }

    /// <inheritdoc />
    public override async Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        var parameters = new InboxConsumerParameters(integrationEvent.Id, _decorated.GetType().FullName!);

        if (await IsInboxMessageConsumedAsync(parameters).ConfigureAwait(false))
        {
            return;
        }

        await _decorated.Handle(integrationEvent, cancellationToken).ConfigureAwait(false);

        await InsertInboxMessageConsumerAsync(parameters).ConfigureAwait(false);
    }

    private async Task<bool> IsInboxMessageConsumedAsync(InboxConsumerParameters parameters)
    {
        const string checkIfConsumedSql = @"
            SELECT EXISTS(
                SELECT 1
                FROM users.inbox_message_consumers
                WHERE id = @Id AND
                      name = @Name
            )";

        return await _sqlQueryExecutor.ExecuteScalarAsync<bool>(checkIfConsumedSql, parameters).ConfigureAwait(false);
    }

    private async Task InsertInboxMessageConsumerAsync(InboxConsumerParameters parameters)
    {
        const string insertConsumedSql = @"
            INSERT INTO users.inbox_message_consumers(id, name)
            VALUES (@Id, @Name)";

        await _sqlQueryExecutor.ExecuteAsync(insertConsumedSql, parameters).ConfigureAwait(false);
    }

    private sealed record InboxConsumerParameters(Guid Id, string Name);
}
