// <copyright file="InfrastructureConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure;

/// <summary>
/// Configuration for the infrastructure.
/// </summary>
public static class InfrastructureConfiguration
{
  /// <summary>
  /// Adds the infrastructure.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="databaseConnectionString">The database connection string.</param>
  /// <param name="redisConnectionString">The cache connection string.</param>
  /// <returns>The IServiceCollection instance.</returns>
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    string databaseConnectionString,
    string redisConnectionString)
  {
    services.AddAuthenticationInternal();

    var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

    services.TryAddSingleton<PublishDomainEventsInterceptor>();

    services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

#pragma warning disable CA1031 // Do not catch general exception types
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
#pragma warning restore CA1031 // Do not catch general exception types

    services.TryAddSingleton<ICacheService, CacheService>();

    services.TryAddSingleton<IEventBus, EventBus.EventBus>();

    services.AddMassTransit(configure =>
    {
      // foreach (var configureConsumer in moduleConfigureConsumers)
      // {
      //   configureConsumer(configure);
      // }
      configure.SetKebabCaseEndpointNameFormatter();

      configure.UsingInMemory((context, cfg) =>
      {
        cfg.ConfigureEndpoints(context);
      });
    });
    return services;
  }
}
