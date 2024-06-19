// <copyright file="ConfigurationExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

/// <summary>
/// Extensions for <see cref="IConfiguration"/>.
/// </summary>
internal static class ConfigurationExtensions
{
  /// <summary>
  /// Adds module configuration files to the configuration builder.
  /// </summary>
  /// <param name="configurationBuilder">The IConfigurationBuilder.</param>
  /// <param name="modules">The modules to add.</param>
  internal static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules)
  {
    foreach (string module in modules)
    {
      configurationBuilder.AddJsonFile($"modules.{module}.json", false, true);
      configurationBuilder.AddJsonFile($"modules.{module}.Development.json", true, true);
    }
  }
}
