// <copyright file="EndpointExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Presentation.Endpoints;

public static class EndpointExtensions
{
  public static IServiceCollection AddEndpoints(this IServiceCollection services, params Assembly[] assemblies)
  {
    ServiceDescriptor[] serviceDescriptors = assemblies
      .SelectMany(a => a.GetTypes())
      .Where(t => t is { IsAbstract: false, IsInterface: false } &&
                  t.IsAssignableTo(typeof(IEndpoint)))
      .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
      .ToArray();

    services.TryAddEnumerable(serviceDescriptors);

    return services;
  }

  public static IApplicationBuilder MapEndpoints(
    this WebApplication app,
    RouteGroupBuilder? routeGroupBuilder = null)
  {
    ArgumentNullException.ThrowIfNull(app);

    var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

    IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

    foreach (var endpoint in endpoints)
    {
      endpoint.MapEndpoint(builder);
    }

    return app;
  }
}
