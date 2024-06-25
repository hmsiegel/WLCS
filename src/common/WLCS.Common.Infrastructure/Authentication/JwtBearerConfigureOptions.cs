// <copyright file="JwtBearerConfigureOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authentication;

/// <summary>
/// Configures the JwtBearerOptions.
/// </summary>
/// <param name="configuration">An instance of IConfiguration.</param>
internal sealed class JwtBearerConfigureOptions(IConfiguration configuration)
  : IConfigureNamedOptions<JwtBearerOptions>
{
  private const string ConfigurationSectionName = "Authentication";
  private readonly IConfiguration _configuration = configuration;

  /// <inheritdoc/>
  public void Configure(string? name, JwtBearerOptions options)
  {
    _configuration.GetSection(ConfigurationSectionName).Bind(options);
  }

  /// <inheritdoc/>
  public void Configure(JwtBearerOptions options)
  {
    Configure(options);
  }
}
