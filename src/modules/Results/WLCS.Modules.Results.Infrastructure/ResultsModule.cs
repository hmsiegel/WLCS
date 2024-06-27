// <copyright file="ResultsModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Results.Infrastructure;

/// <summary>
/// The results module.
/// </summary>
public static class ResultsModule
{
  private const string ModuleName = "Results";

  /// <summary>
  ///  Adds the results module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <param name="logger">The logger.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddResultsModule(
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

    services.AddDbContext<ResultsDbContext>((sp, options) =>
      options
        .UseNpgsql(
          connectionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Results))
        .UseSnakeCaseNamingConvention()
        .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ResultsDbContext>());
  }
}
