namespace Infrastructure.Extensions;

/// <summary>
/// Containes extension methods for <see cref="IRegistrationConfigurator"/> interface.
/// </summary>
public static class RegistrationConfiguratorExtensions
{
    /// <summary>
    /// Adds the consumers from the specified assemblies.
    /// </summary>
    /// <param name="configurator">The registration configurator.</param>
    /// <param name="assemblies">The assemblies to scan for consumers.</param>
    public static void AddConsumersFromAssemblies(this IRegistrationConfigurator configurator, params Assembly[] assemblies) =>
        InstanceFactory
            .CreateFromAssemblies<IConsumerConfiguration>(assemblies)
            .ForEach(installer => installer.AddConsumers(configurator));

    /// <summary>
    /// Adds the request clients from the specified assemblies.
    /// </summary>
    /// <param name="configurator">The registration configurator.</param>
    /// <param name="assemblies">The assemblies to scan for request clients.</param>
    public static void AddRequestClientsFromAssemblies(this IRegistrationConfigurator configurator, params Assembly[] assemblies) =>
        InstanceFactory
            .CreateFromAssemblies<IRequestClientConfiguration>(assemblies)
            .ForEach(installer => installer.AddRequestClients(configurator));
}
