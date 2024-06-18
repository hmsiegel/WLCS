// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competition.Infrastructure;

/// <summary>
/// The events module.
/// </summary>
public static class CompetitionModule
{
  /// <summary>
  ///  Adds the competition module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddCompetitionModule(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssembly(Application.AssemblyReference.Application);
    });

    services.AddValidatorsFromAssembly(Application.AssemblyReference.Application, includeInternalTypes: true);

    services.AddInfrastructure(configuration);

    return services;
  }

  private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var connecstionString = configuration.GetConnectionString("Database");

    var npgsqlDataSource = new NpgsqlDataSourceBuilder(connecstionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

    services.AddDbContext<CompetitionsDbContext>(options =>
      options
        .UseNpgsql(
          connecstionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Competitions))
        .UseSnakeCaseNamingConvention());

    services.AddScoped<IMeetRepository, MeetRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CompetitionsDbContext>());
  }
}
