namespace Modules.Users.Infrastructure.ServiceInstallers;

/// <summary>
/// Represents the <see cref="ProcessInboxMessagesOptions"/> setup.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ProcessInboxMessagesOptionsSetup"/> class.
/// </remarks>
/// <param name="configuration">The configuration.</param>
internal sealed class ProcessInboxMessagesOptionsSetup(IConfiguration configuration) : IConfigureOptions<ProcessInboxMessagesOptions>
{
    private const string _configurationSectionName = "Modules:Users:BackgroundJobs:ProcessInboxMessages";

    /// <inheritdoc />
    public void Configure(ProcessInboxMessagesOptions options) => configuration.GetSection(_configurationSectionName).Bind(options);
}
