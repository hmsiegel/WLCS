﻿// <copyright file="CommunicationModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
using ILogger = Serilog.ILogger;

namespace WLCS.Modules.Communication.Infrastructure;

public static class CommunicationModule
{
  private const string ModuleName = "Communication";

  public static IServiceCollection AddCommunicationModule(
    this IServiceCollection services,
    ILogger logger,
    IConfiguration configuration)
  {
    ArgumentNullException.ThrowIfNull(configuration);
    ArgumentNullException.ThrowIfNull(logger);

    services.AddDomainEventHandlers();

    services.AddIntegrationEventHandlers();

    services.AddInfrastructure(configuration);

    logger.Information("{Module} module services registered.", ModuleName);

    return services;
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<CommunicationDbContext>((sp, options) =>
    {
      options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Communication))
      .UseSnakeCaseNamingConvention()
      .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());
    });

    services.AddTransient<ISendEmail, MimeKitEmailSender>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CommunicationDbContext>());

    services.Configure<OutboxOptions>(configuration.GetSection("Communication:Outbox"));

    services.ConfigureOptions<ConfigureProcessOutboxJob>();

    services.Configure<InboxOptions>(configuration.GetSection("Communication:Inbox"));

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
