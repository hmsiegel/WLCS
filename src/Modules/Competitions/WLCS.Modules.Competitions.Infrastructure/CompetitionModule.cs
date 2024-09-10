﻿// <copyright file="CompetitionModule.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure;

public static class CompetitionModule
{
  public static IServiceCollection AddCompetitionModule(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    ArgumentNullException.ThrowIfNull(configuration);

    services.AddDomainEventHandlers();

    services.AddInfrastructure(configuration);

    services.AddEndpoints(Presentation.AssemblyReference.Assembly);

    return services;
  }

  public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
  {
    ArgumentNullException.ThrowIfNull(registrationConfigurator);

    registrationConfigurator.AddConsumer<AthleteRegisteredIntegrationEventConsumer>();
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
          .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Competitions))
      .UseSnakeCaseNamingConvention()
      .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());
    });

    services.AddScoped<IMeetRepository, MeetRepository>();
    services.AddScoped<ICompetitionRespository, CompetitionRepository>();
    services.AddScoped<IAthleteRepository, AthleteRepository>();

    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CompetitionsDbContext>());

    services.Configure<OutboxOptions>(configuration.GetSection("Competitions:Outbox"));

    services.ConfigureOptions<ConfigureProcessOutboxJob>();
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
}
