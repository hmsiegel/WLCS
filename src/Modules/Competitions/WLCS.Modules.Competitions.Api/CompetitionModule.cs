// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.Api.Database;

namespace WLCS.Modules.Competitions.Api;

public static class CompetitionModule
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    CreateMeet.MapEndpoint(app);
    GetMeet.MapEndpoint(app);
  }

  public static IServiceCollection AddCompetitionModule(
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

    return services;
  }
}
