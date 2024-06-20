// <copyright file="ApplicationConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application;

/// <summary>
/// Configures the application services.
/// </summary>
public static class ApplicationConfiguration
{
  /// <summary>
  /// Adds the application services.
  /// </summary>
  /// <param name="services">The services to add.</param>
  /// <param name="moduleAssemblies">The assemblies containing the services.</param>
  /// <returns>An IService collection instance.</returns>
  public static IServiceCollection AddApplication(
    this IServiceCollection services,
    Assembly[] moduleAssemblies)
  {
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssemblies(moduleAssemblies);

      config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
    });

    services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

    return services;
  }
}
