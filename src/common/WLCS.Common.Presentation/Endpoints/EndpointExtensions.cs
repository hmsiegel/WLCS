// <copyright file="EndpointExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Presentation.Endpoints;

/// <summary>
/// Extension methods for adding and mapping endpoints.
/// </summary>
public static class EndpointExtensions
{
  /// <summary>
  /// Adds all endpoints in the specified assemblies.
  /// </summary>
  /// <param name="services">The services.</param>
  /// <param name="assemblies">The assemblies.</param>
  /// <returns>The service collection.</returns>
  public static IServiceCollection AddEndpoints(this IServiceCollection services, params Assembly[] assemblies)
  {
    var serviceDescriptors = assemblies
      .SelectMany(a => a.GetTypes())
      .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                                  type.IsAssignableTo(typeof(IEndpoint)))
      .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
      .ToArray();

    services.TryAddEnumerable(serviceDescriptors);

    return services;
  }

  /// <summary>
  /// Maps all endpoints to the specified application.
  /// </summary>
  /// <param name="app">Our web application.</param>
  /// <param name="routeGroupBuilder">The groups of endpoints.</param>
  /// <returns>The application.</returns>
  public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
  {
    ArgumentNullException.ThrowIfNull(app);

    var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

    IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

    foreach (IEndpoint endpoint in endpoints)
    {
      endpoint.MapEndpoint(builder);
    }

    return app;
  }
}
