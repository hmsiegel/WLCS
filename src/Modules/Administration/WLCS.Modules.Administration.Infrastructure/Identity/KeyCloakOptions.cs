// <copyright file="KeyCloakOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

internal sealed class KeyCloakOptions
{
  public required string AdminUrl { get; set; }

  public required string TokenUrl { get; set; }

  public required string ConfidentialClientId { get; set; }

  public required string ConfidentialClientSecret { get; set; }

  public required string PublicClientId { get; set; }
}
