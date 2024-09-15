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

    services.AddDomainEventHandlers();

    services.AddIntegrationEventHandlers();

    services.AddInfrastructure(configuration);

    services.AddEndpoints(Presentation.AssemblyReference.Assembly);

    return services;
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddScoped<IPermissionService, PermissionService>();

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
      .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());
    });

    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IRolesService, RolesService>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AdministrationDbContext>());

    services.Configure<OutboxOptions>(configuration.GetSection("Administration:Outbox"));

    services.ConfigureOptions<ConfigureProcessOutboxJob>();

    services.Configure<InboxOptions>(configuration.GetSection("Administration:Inbox"));

    services.ConfigureOptions<ConfigureProcessInboxJob>();
  }

  private static void AddDomainEventHandlers(this IServiceCollection services)
  {
    Type[] domainEventHandlers = Application.AssemblyReference.Assembly
      .GetTypes()
      .Where(t => t.IsAssignableTo(typeof(IDomainEventHandler)))
      .ToArray();

    foreach (var domainEventHandler in domainEventHandlers)
    {
      services.TryAddScoped(domainEventHandler);

      var domainEvent = domainEventHandler
        .GetInterfaces()
        .Single(i => i.IsGenericType)
        .GetGenericArguments()
        .Single();

      var closedIdempotentHandler = typeof(IdempotentDomainEventHandler<>)
        .MakeGenericType(domainEvent);

      services.Decorate(
        domainEventHandler,
        closedIdempotentHandler);
    }
  }

  private static void AddIntegrationEventHandlers(this IServiceCollection services)
  {
    Type[] integrationEventHandlers = Presentation.AssemblyReference.Assembly
      .GetTypes()
      .Where(t => t.IsAssignableTo(typeof(IIntegrationEventHandler)))
      .ToArray();

    foreach (var integrationEventHandler in integrationEventHandlers)
    {
      services.TryAddScoped(integrationEventHandler);

      var integrationEvent = integrationEventHandler
        .GetInterfaces()
        .Single(i => i.IsGenericType)
        .GetGenericArguments()
        .Single();

      var closedIdempotentHandler = typeof(IdempotentIntegrationEventHandler<>)
        .MakeGenericType(integrationEvent);

      services.Decorate(
        integrationEventHandler,
        closedIdempotentHandler);
    }
  }
}
