// <copyright file="AuthenticationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authentication;

/// <summary>
/// Extension methods for adding authentication services to the DI container.
/// </summary>
internal static class AuthenticationExtensions
{
  /// <summary>
  /// Adds authentication services to the DI container.
  /// </summary>
  /// <param name="services">The IServiceCollection instance.</param>
  /// <returns>The collection of services.</returns>
  internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
  {
    services.AddAuthorization();

    services.AddAuthentication().AddJwtBearer();

    services.AddHttpContextAccessor();

    services.ConfigureOptions<JwtBearerConfigureOptions>();

    return services;
  }
}
