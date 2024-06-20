// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
using Serilog;

namespace WLCS.Modules.Competition.Infrastructure;

/// <summary>
/// The competition module.
/// </summary>
public static class CompetitionModule
{
  private const string ModuleName = "Competition";

  /// <summary>
  ///  Adds the competition module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <param name="logger">The logger.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddCompetitionModule(this IServiceCollection services, IConfiguration configuration, ILogger logger)
  {
    services.AddInfrastructure(configuration);

    ArgumentNullException.ThrowIfNull(logger);

    logger.Information("{module} module added.", ModuleName);

    return services;
  }

  private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var connecstionString = configuration.GetConnectionString("Database");

    services.AddDbContext<CompetitionsDbContext>(options =>
      options
        .UseNpgsql(
          connecstionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Competitions))
        .UseSnakeCaseNamingConvention()
        .AddInterceptors());

    services.AddScoped<IMeetRepository, MeetRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CompetitionsDbContext>());
  }
}
