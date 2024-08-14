// <copyright file="InfrastructureConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure;

public static class InfrastructureConfiguration
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
  {
    var npgsqlDataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
    services.TryAddSingleton(npgsqlDataSource);

    services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
    services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

    return services;
  }
}
