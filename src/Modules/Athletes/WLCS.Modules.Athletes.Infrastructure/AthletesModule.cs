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

    services.AddDomainEventHandlers();

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
