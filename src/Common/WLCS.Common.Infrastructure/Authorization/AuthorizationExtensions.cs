// <copyright file="AuthorizationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

internal static class AuthorizationExtensions
{
  internal static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
  {
    services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();

    services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

    services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

    return services;
  }
}
