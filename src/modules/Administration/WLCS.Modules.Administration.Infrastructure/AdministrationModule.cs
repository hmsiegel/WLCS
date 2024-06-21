// <copyright file="AdministrationModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Administration.Infrastructure;

/// <summary>
/// The administration module.
/// </summary>
public static class AdministrationModule
{
  private const string ModuleName = "Administration";

  /// <summary>
  ///  Adds the competition module.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="configuration">The configuration.</param>
  /// <param name="logger">The logger.</param>
  /// <returns>Services.</returns>
  public static IServiceCollection AddAdministrationModule(this IServiceCollection services, IConfiguration configuration, ILogger logger)
  {
    services.AddInfrastructure(configuration);

    ArgumentNullException.ThrowIfNull(logger);

    logger.Information("{module} module added.", ModuleName);

    return services;
  }

  private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var connecstionString = configuration.GetConnectionString("Database");

    services.AddDbContext<AdministrationDbContext>((sp, options) =>
      options
        .UseNpgsql(
          connecstionString,
          npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Administration))
        .UseSnakeCaseNamingConvention()
        .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AdministrationDbContext>());
  }
}
