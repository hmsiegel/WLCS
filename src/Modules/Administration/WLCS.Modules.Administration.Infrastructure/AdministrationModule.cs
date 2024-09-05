// <copyright file="AdministrationModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure;

public static class AdministrationModule
{
  public static IServiceCollection AddAdministrationModule(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    ArgumentNullException.ThrowIfNull(configuration);

    services.AddInfrastructure(configuration);

    return services;
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.Configure<KeyCloakOptions>(configuration.GetSection("Administration:KeyCloak"));

    services.AddTransient<KeyCloakAuthDelegatingHandler>();

    services
      .AddHttpClient<KeyCloakClient>((sp, client) =>
      {
        var options = sp.GetRequiredService<IOptions<KeyCloakOptions>>().Value;

        client.BaseAddress = new Uri(options.AdminUrl);
      })
      .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

    services.AddTransient<IIdentityProviderService, IdentityProviderService>();

    var connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<AdministrationDbContext>((sp, options) =>
    {
      options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Administration))
      .UseSnakeCaseNamingConvention()
      .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
    });

    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AdministrationDbContext>());
  }
}
