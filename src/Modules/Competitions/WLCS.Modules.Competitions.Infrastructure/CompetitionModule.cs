// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure;

public static class CompetitionModule
{
  public static IServiceCollection AddCompetitionModule(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddInfrastructure(configuration);

    return services;
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<CompetitionsDbContext>(options =>
    {
      options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Competitions))
      .UseSnakeCaseNamingConvention();
    });

    services.AddScoped<IMeetRepository, MeetRepository>();
    services.AddScoped<ICompetitionRespository, CompetitionRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CompetitionsDbContext>());
  }
}
