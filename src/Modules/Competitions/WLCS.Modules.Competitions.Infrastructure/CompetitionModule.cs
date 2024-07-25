// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure;

public static class CompetitionModule
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    MeetEndpoints.MapEndpoints(app);
  }

  public static IServiceCollection AddCompetitionModule(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssembly(Application.AssemblyReference.Application);
    });

    services.AddValidatorsFromAssembly(Application.AssemblyReference.Application, includeInternalTypes: true);

    services.AddInfrastructure(configuration);

    return services;
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database");

    var npgsqlDataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

    services.AddDbContext<CompetitionsDbContext>(options =>
    {
      options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Competitions))
      .UseSnakeCaseNamingConvention();
    });

    services.AddScoped<IMeetRepository, MeetRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CompetitionsDbContext>());
  }
}
