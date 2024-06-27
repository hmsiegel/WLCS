// <copyright file="ClaimsPrincipalExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authentication;

/// <summary>
/// Represents extension methods for gettings claims from a <see cref="ClaimsPrincipal"/>.
/// </summary>
public static class ClaimsPrincipalExtensions
{
  /// <summary>
  /// Gets the user identifier from the claims principal.
  /// </summary>
  /// <param name="claimsPrincipal">The user's claims princial.</param>
  /// <returns>The user Id.</returns>
  /// <exception cref="WLCSException">Thrown if the user Id is unavailable.</exception>
  public static Guid GetUserId(this ClaimsPrincipal? claimsPrincipal)
  {
    var userId = claimsPrincipal?.FindFirst(CustomClaims.Sub)?.Value;
    return Guid.TryParse(userId, out Guid parsedUserId) ?
      parsedUserId :
      throw new WLCSException("User identifier is unavailable.");
  }

  /// <summary>
  /// Gets the user identity from the claims principal.
  /// </summary>
  /// <param name="claimsPrincipal">The user's claims princial.</param>
  /// <returns>The user Id.</returns>
  /// <exception cref="WLCSException">Thrown if the user identity is unavailable.</exception>
  public static string GetIdentityId(this ClaimsPrincipal? claimsPrincipal)
  {
    return claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
      throw new WLCSException("User identity is unavailable.");
  }

  /// <summary>
  /// Gets the user's permissions from the claims principal.
  /// </summary>
  /// <param name="claimsPrincipal">The user's claims principal.</param>
  /// <returns>The user's permissions.</returns>
  /// <exception cref="WLCSException">Thrown if the permission's are unavailable.</exception>
  public static HashSet<string> GetPermissions(this ClaimsPrincipal claimsPrincipal)
  {
    var permissions = claimsPrincipal?.FindAll(CustomClaims.Permission) ??
      throw new WLCSException("Permissions are unavailable.");

    return permissions.Select(p => p.Value).ToHashSet();
  }
}
