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
  /// <returns>The IServiceCollection instance.</returns>
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    string databaseConnectionString)
  {
    var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

    services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

    return services;
  }
}
