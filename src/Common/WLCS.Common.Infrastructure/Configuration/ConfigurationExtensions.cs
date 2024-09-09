// <copyright file="ConfigurationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Configuration;

public static class ConfigurationExtensions
{
  public static string GetConnectionStringOrThrow(this IConfiguration configuration, string name)
  {
    return configuration.GetConnectionString(name) ??
      throw new InvalidOperationException($"Connection string '{name}' not found.");
  }

  public static T GetValueOrThrow<T>(this IConfiguration configuration, string name)
  {
    return configuration.GetValue<T?>(name) ??
      throw new InvalidOperationException($"Value '{name}' not found.");
  }
}
