// <copyright file="AuthorizationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

/// <summary>
/// Registers the authorization services.
/// </summary>
internal static class AuthorizationExtensions
{
  /// <summary>
  /// Adds the authorization services.
  /// </summary>
  /// <param name="services">The IServiceCollection.</param>
  /// <returns>The services.</returns>
  internal static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
  {
    services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();

    services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

    services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

    return services;
  }
}
