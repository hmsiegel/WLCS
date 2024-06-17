// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competition.Api;

/// <summary>
/// The events module.
/// </summary>
public static class CompetitionModule
{
  /// <summary>
  /// Maps the endpoints.
  /// </summary>
  /// <param name="app">The IEndpointRouteBuild to pass in.</param>
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    GetMeet.MapEndpoint(app);
    CreateMeet.MapEndpoint(app);
  }

  /// <summary>
  ///  Adds the competition module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddCompetitionModule(this IServiceCollection services, IConfiguration configuration)
  {
    var connecstionString = configuration.GetConnectionString("Database");

    services.AddDbContext<CompetitionsDbContext>(options =>
      options
        .UseNpgsql(
          connecstionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Competition))
        .UseSnakeCaseNamingConvention());

    return services;
  }
}
