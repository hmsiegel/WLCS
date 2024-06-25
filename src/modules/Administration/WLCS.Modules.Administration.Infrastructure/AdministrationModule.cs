// <copyright file="AdministrationModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using ILogger = Serilog.ILogger;

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
  public static IServiceCollection AddAdministrationModule(
    this IServiceCollection services,
    IConfiguration configuration,
    ILogger logger)
  {
    ArgumentNullException.ThrowIfNull(configuration);

    services.AddInfrastructure(configuration);

    ArgumentNullException.ThrowIfNull(logger);

    logger.Information("{module} module added.", ModuleName);

    return services;
  }

  private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var connecstionString = configuration.GetConnectionString("Database");

    services.Configure<KeyCloakOptions>(configuration.GetSection("Administration:KeyCloak"));

    services.AddTransient<KeyCloakAuthDelegatingHandler>();

    services.AddHttpClient<KeyCloakClient>((sp, http) =>
    {
      var keyCloakOptions = sp.GetRequiredService<IOptions<KeyCloakOptions>>().Value;

      http.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
    })
    .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

    services.AddTransient<IIdentityProviderService, IdentityProviderService>();

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
