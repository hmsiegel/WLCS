namespace Modules.Users.Infrastructure.ServiceInstallers;

/// <summary>
/// Represents the users module authorization service installer.
/// </summary>
internal sealed class AuthorizationServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
            .AddHttpContextAccessor()
            .ConfigureOptions<AuthorizationOptionsSetup>()
            .ConfigureOptions<SameUserAuthorizationOptionsSetup>()
            .AddTransient<IUserChecker, UserChecker>()
            .AddSingleton<IAuthorizationHandler, SameUserAuthorizationHandler>();
}
