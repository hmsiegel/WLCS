// <copyright file="AuthServiceCollectionExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.MockAuthentication;

public static class AuthServiceCollectionExtensions
{
  public static AuthenticationBuilder AddMockAuthentication(this IServiceCollection services)
  {
    services.AddAuthorizationBuilder()
      .SetDefaultPolicy(new AuthorizationPolicyBuilder(AuthConstants.Scheme)
      .RequireAuthenticatedUser()
      .Build());

    return services.AddAuthentication(AuthConstants.Scheme)
      .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(AuthConstants.Scheme, options => { });
  }
}
