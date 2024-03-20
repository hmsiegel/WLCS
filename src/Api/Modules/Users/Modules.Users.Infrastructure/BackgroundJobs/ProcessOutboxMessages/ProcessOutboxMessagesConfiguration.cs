namespace Modules.Users.Infrastructure.BackgroundJobs.ProcessOutboxMessages;

/// <summary>
/// Represents the <see cref="ProcessOutboxMessagesJob"/> configuration.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ProcessOutboxMessagesConfiguration"/> class.
/// </remarks>
/// <param name="options">The options.</param>
internal sealed class ProcessOutboxMessagesConfiguration(IOptions<ProcessOutboxMessagesOptions> options) : IRecurringJobConfiguration
{
    private readonly ProcessOutboxMessagesOptions _options = options.Value;

    /// <inheritdoc />
    public string Name => typeof(ProcessOutboxMessagesJob).FullName!;

    /// <inheritdoc />
    public Type Type => typeof(ProcessOutboxMessagesJob);

    /// <inheritdoc />
    public int IntervalInSeconds => _options.IntervalInSeconds;
}
