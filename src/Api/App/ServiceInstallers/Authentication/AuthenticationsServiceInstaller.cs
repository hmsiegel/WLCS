namespace App.ServiceInstallers.Authentication;

/// <summary>
/// Represents the authentications service installer.
/// </summary>
internal sealed class AuthenticationsServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureOptions<AuthenticationOptionsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>()
            .AddAuthentication()
            .AddJwtBearer()
            .Tap(ReplaceSubClaimWithName);
    }

    private static void ReplaceSubClaimWithName() =>
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub] = ClaimTypes.NameIdentifier;
}
