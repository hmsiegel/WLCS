// <copyright file="CommunicationModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure;

/// <summary>
/// The communication module.
/// </summary>
public static class CommunicationModule
{
  private const string ModuleName = "Communication";

  /// <summary>
  ///  Adds the competition module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <param name="logger">The logger.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddCommunicationModule(
    this IServiceCollection services,
    IConfiguration configuration,
    ILogger logger)
  {
    services.AddInfrastructure(configuration);
    services.AddEndpoints(Presentation.AssemblyReference.Presentation);

    ArgumentNullException.ThrowIfNull(logger);

    logger.Information("{module} module added.", ModuleName);

    return services;
  }

  private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<CommunicationDbContext>((sp, options) =>
      options
        .UseNpgsql(
          connectionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Communication))
        .UseSnakeCaseNamingConvention()
        .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CommunicationDbContext>());
  }
}
