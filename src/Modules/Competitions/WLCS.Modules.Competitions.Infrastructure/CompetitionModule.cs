﻿// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
using WLCS.Modules.Competitions.Application.Abstractions.Data;

using ILogger = Serilog.ILogger;

namespace WLCS.Modules.Competitions.Infrastructure;

public static class CompetitionModule
{
  private const string ModuleName = "Competition";

  public static IServiceCollection AddCompetitionModule(
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

  public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator, string instanceId)
  {
    ArgumentNullException.ThrowIfNull(registrationConfigurator);

    registrationConfigurator.AddConsumer<IntegrationEventConsumer<AthleteRegisteredIntegrationEvent>>()
      .Endpoint(c => c.InstanceId = instanceId);
  }

  private static void AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database");

    services.AddDbContext<CompetitionsDbContext>((sp, options) =>
    {
      options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, DatabaseSchemaConstants.Competitions))
      .UseSnakeCaseNamingConvention()
      .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());
    });

    RepositoryExtensions<CompetitionsDbContext>.RegisterRepositories(services);

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CompetitionsDbContext>());

    services.Configure<OutboxOptions>(configuration.GetSection("Competitions:Outbox"));

    services.ConfigureOptions<ConfigureProcessOutboxJob>();

    services.Configure<InboxOptions>(configuration.GetSection("Competitions:Inbox"));

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
