// <copyright file="CustomClaims.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authentication;

/// <summary>
/// Represents the custom claims.
/// </summary>
public static class CustomClaims
{
  /// <summary>
  /// Represents the subject of the claim.
  /// </summary>
  public const string Sub = "sub";

  /// <summary>
  ///  represents the permission of the claim.
  /// </summary>
  public const string Permission = "permission";
}
