namespace Modules.Users.Infrastructure.Authorization.SameUser.Options;

/// <summary>
/// Represents the <see cref="SameUserAuthorizationOptions"/> setup.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SameUserAuthorizationOptionsSetup"/> class.
/// </remarks>
/// <param name="configuration">The configuration.</param>
internal sealed class SameUserAuthorizationOptionsSetup(IConfiguration configuration) : IConfigureOptions<SameUserAuthorizationOptions>
{
    private const string _configurationSectionName = "Modules:Users:Authorization:SameUser";

    /// <inheritdoc/>
    public void Configure(SameUserAuthorizationOptions options)
    {
        configuration.GetSection(_configurationSectionName).Bind(options);
    }
}
