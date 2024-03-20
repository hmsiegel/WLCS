using SystemTime = Infrastructure.Time.SystemTime;

namespace Modules.Users.Infrastructure.ServiceInstallers;

/// <summary>
/// Represents the users module infrastructure service installer.
/// </summary>
internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
            .Tap(services.TryAddTransient<ISystemTime, SystemTime>)
            .Tap(services.TryAddTransient<IEventBus, EventBus>);
}
