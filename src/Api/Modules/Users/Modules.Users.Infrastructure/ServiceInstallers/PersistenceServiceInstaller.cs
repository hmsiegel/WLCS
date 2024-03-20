namespace Modules.Users.Infrastructure.ServiceInstallers;

/// <summary>
/// Represents the users module persistence service installer.
/// </summary>
internal sealed class PersistenceServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
            .Tap(services.TryAddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>)
            .Tap(services.TryAddSingleton<UpdateAuditableEntitiesInterceptor>)
            .AddDbContext<UsersDbContext>((serviceProvider, options) =>
            {
                ConnectionStringOptions connectionString = serviceProvider.GetService<IOptions<ConnectionStringOptions>>()!.Value;

                options
                    .UseNpgsql(
                        connectionString,
                        dbContextOptionsBuilder => dbContextOptionsBuilder.WithMigrationHistoryTableInSchema(Schemas.Users))
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(
                        serviceProvider.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>()!,
                        serviceProvider.GetService<UpdateAuditableEntitiesInterceptor>()!);
            });
}
