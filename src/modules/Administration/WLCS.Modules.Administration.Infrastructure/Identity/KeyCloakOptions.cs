// <copyright file="KeyCloakOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// The KeyCloak options.
/// </summary>
internal sealed class KeyCloakOptions
{
  /// <summary>
  /// Gets or sets the base address of the Key Cloak admin REST API.
  /// </summary>
  public string AdminUrl { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the URL to obtain an access token.
  /// </summary>
  public string TokenUrl { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the confidential client ID.
  /// </summary>
  public string ConfidentialClientId { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the confidential client secret.
  /// </summary>
  public string ConfidentialClientSecret { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the public client ID.
  /// </summary>
  public string PublicClientId { get; set; } = string.Empty;
}
