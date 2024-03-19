namespace App.ServiceInstallers.Authentication;

/// <summary>
/// Represents the <see cref="JwtBearerOptions"/> setup.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="JwtBearerOptionsSetup"/> class.
/// </remarks>
/// <param name="configuration">The configuration.</param>
internal sealed class JwtBearerOptionsSetup(IConfiguration configuration) : IConfigureNamedOptions<JwtBearerOptions>
{
    private const string _configurationSectionName = "JwtBearer";

    /// <inheritdoc />
    public void Configure(string? name, JwtBearerOptions options) => configuration.GetSection(_configurationSectionName).Bind(options);

    /// <inheritdoc />
    public void Configure(JwtBearerOptions options) => configuration.GetSection(_configurationSectionName).Bind(options);
}
