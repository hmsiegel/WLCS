﻿// <copyright file="KeyCloakHealthChecksBuilderExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

internal static class KeyCloakHealthChecksBuilderExtensions
{
  private const string KeyCloakHealthCheck = "KeyCloak";
  private const string KeyCloakHealthUrl = "KeyCloak:HealthUrl";

  internal static IHealthChecksBuilder AddKeyCloak(this IHealthChecksBuilder builder, Uri healthUri)
  {
    builder.AddUrlGroup(uri: healthUri, httpMethod: HttpMethod.Get, name: KeyCloakHealthCheck);

    return builder;
  }

  internal static Uri GetKeyCloakHealthUrl(this IConfiguration configuration)
  {
    return new Uri(configuration.GetValueOrThrow<string>(KeyCloakHealthUrl));
  }
}
