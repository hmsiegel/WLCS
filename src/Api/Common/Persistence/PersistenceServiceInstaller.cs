namespace Persistence;

/// <summary>
/// Represents the persistence service installer.
/// </summary>
internal sealed class PersistenceServiceInstaller : IServiceInstaller
{
    /// <inheritdoc/>
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
        .AddMemoryCache()
        .ConfigureOptions<ConnectionStringSetup>()
        .AddTransientAsMatchingInterface(AssemblyReference.Assembly)
        .Tap(() => Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true);
}
