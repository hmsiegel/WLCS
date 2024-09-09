// <copyright file="AthletesModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure;

public static class AthletesModule
{
  public static IServiceCollection AddAthletesModules(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    ArgumentNullException.ThrowIfNull(configuration);

    services.AddInfrastructure(configuration);

    services.AddEndpoints(Presentation.AssemblyReference.Assembly);

    return services;
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<AthletesDbContext>((sp, options) =>
    {
      options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Athletes))
      .UseSnakeCaseNamingConvention()
      .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());
    });

    services.AddScoped<IAthleteRepository, AthleteRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AthletesDbContext>());

    services.Configure<OutboxOptions>(configuration.GetSection("Athletes:Outbox"));

    services.ConfigureOptions<ConfigureProcessOutboxJob>();
  }
}
