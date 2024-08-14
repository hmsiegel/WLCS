// <copyright file="ApplicationConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application;

public static class ApplicationConfiguration
{
  public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
  {
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssemblies(moduleAssemblies);
    });

    services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

    return services;
  }
}
