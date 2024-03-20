namespace Modules.Users.Infrastructure.ServiceInstallers;

/// <summary>
/// Represents the <see cref="ProcessOutboxMessagesOptions"/> setup.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ProcessOutboxMessagesOptionsSetup"/> class.
/// </remarks>
/// <param name="configuration">The configuration.</param>
internal sealed class ProcessOutboxMessagesOptionsSetup(IConfiguration configuration) : IConfigureOptions<ProcessOutboxMessagesOptions>
{
    private const string _configurationSectionName = "Modules:Users:BackgroundJobs:ProcessOutboxMessages";

    /// <inheritdoc />
    public void Configure(ProcessOutboxMessagesOptions options) => configuration.GetSection(_configurationSectionName).Bind(options);
}
