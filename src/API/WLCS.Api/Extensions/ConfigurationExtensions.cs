// <copyright file="ConfigurationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

internal static class ConfigurationExtensions
{
  internal static void AddModuleConfiguration(this WebApplicationBuilder builder, string[] modules)
  {
   foreach (var module in modules)
    {
      builder.Configuration.AddJsonFile($"modules.{module}.json", optional: false, true);
      builder.Configuration.AddJsonFile($"modules.{module}.Development.json", optional: true, true);
    }
  }
}
