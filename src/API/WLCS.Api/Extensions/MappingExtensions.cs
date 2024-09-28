// <copyright file="MappingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using IMapper = MapsterMapper.IMapper;

namespace WLCS.Api.Extensions;

public static class MappingExtensions
{
  public static IServiceCollection AddMappings(this IServiceCollection services, Assembly[] assemblies)
  {
    var config = TypeAdapterConfig.GlobalSettings;
    config.Scan(assemblies);

    services.AddSingleton(config);
    services.AddScoped<IMapper, ServiceMapper>();

    return services;
  }
}
