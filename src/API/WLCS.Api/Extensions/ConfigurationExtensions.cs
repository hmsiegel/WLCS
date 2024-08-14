// <copyright file="ConfigurationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

internal static class ConfigurationExtensions
{
  internal static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules)
  {
   foreach (var module in modules)
    {
      configurationBuilder.AddJsonFile($"modules.{module}.json", optional: false, true);
      configurationBuilder.AddJsonFile($"modules.{module}.Development.json", optional: true, true);
    }
  }
}
