namespace Authorization.Options;

/// <summary>
/// Represents the setup of the <see cref="PermissionAuthorizationOptions"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PermissionAuthorizationOptionsSetup"/> class.
/// </remarks>
/// <param name="configuration">The configuration.</param>
internal sealed class PermissionAuthorizationOptionsSetup(IConfiguration configuration) : IConfigureOptions<PermissionAuthorizationOptions>
{
    private const string _configurationSection = "Authorization:Permissions";

    /// <inheritdoc/>
    public void Configure(PermissionAuthorizationOptions options)
    {
        configuration.GetSection(_configurationSection).Bind(options);
    }
}
