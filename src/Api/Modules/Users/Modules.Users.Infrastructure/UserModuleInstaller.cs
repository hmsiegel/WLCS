namespace Modules.Users.Infrastructure;

/// <summary>
/// Represent the user module installer.
/// </summary>
public sealed class UserModuleInstaller : IModuleInstaller
{
    /// <inheritdoc/>
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .InstallServicesFromAssemblies(configuration, AssemblyReference.Assembly)
            .AddTransientAsMatchingInterface(AssemblyReference.Assembly)
            .AddTransientAsMatchingInterface(Persistence.AssemblyReference.Assembly)
            .AddScopedAsMatchingInterface(AssemblyReference.Assembly)
            .AddScopedAsMatchingInterface(Persistence.AssemblyReference.Assembly);
    }
}
