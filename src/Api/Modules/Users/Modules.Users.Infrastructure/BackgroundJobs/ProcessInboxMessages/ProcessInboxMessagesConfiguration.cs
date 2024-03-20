namespace Modules.Users.Infrastructure.BackgroundJobs.ProcessInboxMessages;

/// <summary>
/// Represents the <see cref="ProcessInboxMessagesJob"/> configuration.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ProcessInboxMessagesConfiguration"/> class.
/// </remarks>
/// <param name="options">The options.</param>
internal sealed class ProcessInboxMessagesConfiguration(IOptions<ProcessInboxMessagesOptions> options) : IRecurringJobConfiguration
{
    private readonly ProcessInboxMessagesOptions _options = options.Value;

    /// <inheritdoc />
    public string Name => typeof(ProcessInboxMessagesJob).FullName!;

    /// <inheritdoc />
    public Type Type => typeof(ProcessInboxMessagesJob);

    /// <inheritdoc />
    public int IntervalInSeconds => _options.IntervalInSeconds;
}
