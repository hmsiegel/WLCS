using Scrutor;

namespace Infrastructure.Extensions;

/// <summary>
/// Contains extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Installs the services using the <see cref="IServiceInstaller"/> implementations found in the specified assemblies.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="assemblies">The assemblies to scan for service installer implementations.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection InstallServicesFromAssemblies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies) =>
        services.Tap(
        () => InstanceFactory
                .CreateFromAssemblies<IServiceInstaller>(assemblies)
                .ForEach(installer => installer.Install(services, configuration)));

    /// <summary>
    /// Installs the services using the <see cref="IModuleInstaller"/> implementations found in the specified assemblies.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="assemblies">The assemblies to scan for module installer implementations.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection InstallModulesFromAssemblies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies) =>
        services.Tap(
        () => InstanceFactory
                .CreateFromAssemblies<IModuleInstaller>(assemblies)
                .ForEach(installer => installer.Install(services, configuration)));

    /// <summary>
    /// Adds all of the implementations of the <see cref="ITransient"/> interface found in the specified assemblies to the service collection.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="assembly">The assembly to scan for transient services.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddTransientAsMatchingInterface(this IServiceCollection services, Assembly assembly) =>
        services.Scan(scan =>
            scan
               .FromAssemblies(assembly)
               .AddClasses(classes => classes.AssignableTo<ITransient>(), false)
               .UsingRegistrationStrategy(RegistrationStrategy.Throw)
               .AsMatchingInterface()
               .WithTransientLifetime());

    /// <summary>
    /// Adds all of the implementations of the <see cref="IScoped"/> interface found in the specified assemblies to the service collection.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="assembly">The assembly to scan for scoped services.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddScopedAsMatchingInterface(this IServiceCollection services, Assembly assembly) =>
        services.Scan(scan =>
            scan
               .FromAssemblies(assembly)
               .AddClasses(classes => classes.AssignableTo<IScoped>(), false)
               .UsingRegistrationStrategy(RegistrationStrategy.Throw)
               .AsMatchingInterface()
               .WithTransientLifetime());
}
