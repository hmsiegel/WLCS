namespace Modules.Users.Infrastructure.BackgroundJobs.ProcessOutboxMessages;

/// <summary>
/// Represents the background job for processing outbox messages.
/// </summary>
[DisallowConcurrentExecution]
internal sealed class ProcessOutboxMessagesJob : IJob
{
    private static readonly JsonSerializerSettings _jsonSerializerSettings = new ()
    {
        TypeNameHandling = TypeNameHandling.All,
    };

    private readonly ISqlQueryExecutor _sqlQueryExecutor;
    private readonly IPublisher _publisher;
    private readonly ISystemTime _systemTime;
    private readonly ProcessOutboxMessagesOptions _options;
    private readonly AsyncRetryPolicy _policy;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessOutboxMessagesJob"/> class.
    /// </summary>
    /// <param name="sqlQueryExecutor">The SQL query executor.</param>
    /// <param name="publisher">The publisher.</param>
    /// <param name="systemTime">The system time.</param>
    /// <param name="options">The options.</param>
    public ProcessOutboxMessagesJob(
        ISqlQueryExecutor sqlQueryExecutor,
        IPublisher publisher,
        ISystemTime systemTime,
        IOptions<ProcessOutboxMessagesOptions> options)
    {
        _sqlQueryExecutor = sqlQueryExecutor;
        _publisher = publisher;
        _systemTime = systemTime;
        _options = options.Value;
        _policy = Policy.Handle<Exception>().RetryAsync(_options.RetryCount);
    }

    /// <inheritdoc />
    public async Task Execute(IJobExecutionContext context)
    {
        List<OutboxMessageResponse> outboxMessagesList = await GetOutboxMessagesAsync().ConfigureAwait(false);

        if (outboxMessagesList.Count == 0)
        {
            return;
        }

        foreach (OutboxMessageResponse outboxMessage in outboxMessagesList)
        {
            IDomainEvent domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(outboxMessage.Content, _jsonSerializerSettings)!;

            PolicyResult result = await _policy.ExecuteAndCaptureAsync(() => _publisher.Publish(domainEvent, context.CancellationToken)).ConfigureAwait(false);

            await UpdateOutboxMessageAsync(outboxMessage, result.FinalException).ConfigureAwait(false);
        }
    }

    private async Task<List<OutboxMessageResponse>> GetOutboxMessagesAsync()
    {
        string getOutboxMessagesSql = $@"
            SELECT id, content
            FROM users.outbox_messages
            WHERE processed_on_utc IS NULL
            ORDER BY occurred_on_utc
            LIMIT {_options.BatchSize}";

        IEnumerable<OutboxMessageResponse> outboxMessages = await _sqlQueryExecutor.QueryAsync<OutboxMessageResponse>(getOutboxMessagesSql).ConfigureAwait(false);

        return outboxMessages.ToList();
    }

    private async Task UpdateOutboxMessageAsync(OutboxMessageResponse outboxMessage, Exception? exception)
    {
        const string updateOutboxMessageSql = @"
            UPDATE users.outbox_messages
            SET processed_on_utc = @ProcessedOnUtc,
                error = @Error
            WHERE id = @Id";

        await _sqlQueryExecutor.ExecuteAsync(
            updateOutboxMessageSql,
            new
            {
                outboxMessage.Id,
                ProcessedOnUtc = _systemTime.UtcNow,
                Error = exception?.ToString(),
            }).ConfigureAwait(false);
    }

    internal sealed record OutboxMessageResponse(Guid Id, string Content);
}
