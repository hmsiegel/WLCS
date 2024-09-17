// <copyright file="JwtBearerConfigureOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Gateway.Authentication;

internal sealed class JwtBearerConfigureOptions(IConfiguration configuration)
  : IConfigureNamedOptions<JwtBearerOptions>
{
  private const string ConfigurationSectionName = "Authentication";

  private readonly IConfiguration _configuration = configuration;

  public void Configure(JwtBearerOptions options)
  {
    _configuration.GetSection(ConfigurationSectionName).Bind(options);
  }

  [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Reviewed")]
  public void Configure(string? name, JwtBearerOptions options)
  {
    Configure(options);
  }
}
