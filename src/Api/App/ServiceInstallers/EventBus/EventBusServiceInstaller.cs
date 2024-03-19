namespace App.ServiceInstallers.EventBus;

/// <summary>
/// Represents the event bus service installer.
/// </summary>
internal sealed class EventBusServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureOptions<MassTransitHostOptionsSetup>()
            .AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddRequestClientsFromAssemblies(
                    Authorization.AssemblyReference.Assembly);

                busConfigurator.UsingInMemory((context, configurator) =>
                    configurator.ConfigureEndpoints(context));
            });
    }
}
