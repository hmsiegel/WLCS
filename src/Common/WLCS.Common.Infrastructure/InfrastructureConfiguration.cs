// <copyright file="InfrastructureConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure;

public static class InfrastructureConfiguration
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
    string databaseConnectionString,
    string redisConnectionString)
  {
    var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

    services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

    services.TryAddSingleton<PublishDomainEventsInterceptor>();

    try
    {
      IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
      services.TryAddSingleton(connectionMultiplexer);

      services.AddStackExchangeRedisCache(options =>
        options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
    }
    catch
    {
      services.AddDistributedMemoryCache();
    }

    services.TryAddSingleton<ICacheService, CacheService>();

    services.TryAddSingleton<IEventBus, EventBus.EventBus>();

    services.AddMassTransit(configure =>
    {
      foreach (var configureConsumer in moduleConfigureConsumers)
      {
        configureConsumer(configure);
      }

      configure.SetKebabCaseEndpointNameFormatter();

      configure.UsingInMemory((context, cfg) =>
      {
        cfg.ConfigureEndpoints(context);
      });
    });

    return services;
  }
}
