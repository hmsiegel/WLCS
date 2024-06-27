// <copyright file="SchedulingModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Scheduling.Infrastructure;

/// <summary>
/// The competition module.
/// </summary>
public static class SchedulingModule
{
  private const string ModuleName = "Scheduling";

  /// <summary>
  ///  Adds the competition module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <param name="logger">The logger.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddSchedulingModule(
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

    services.AddDbContext<SchedulingDbContext>((sp, options) =>
      options
        .UseNpgsql(
          connectionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Scheduling))
        .UseSnakeCaseNamingConvention()
        .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SchedulingDbContext>());
  }
}
