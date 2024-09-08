// <copyright file="ClaimsPrincipalExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
  public static Guid GetUserId(this ClaimsPrincipal? principal)
  {
    var userId = principal?.FindFirst(CustomClaims.Sub)?.Value;

    return Guid.TryParse(userId, out Guid parsedUserId) ?
      parsedUserId :
      throw new WlcsException("User identifier is unavailable.");
  }

  public static string GetIdentityId(this ClaimsPrincipal? principal)
  {
    return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
      throw new WlcsException("User identity is unavailable.");
  }

  public static HashSet<string> GetPermissions(this ClaimsPrincipal? principal)
  {
    IEnumerable<Claim> permissionClaims = principal?.FindAll(CustomClaims.Permission) ??
      throw new WlcsException("Permissions are unavailable.");

    return permissionClaims.Select(c => c.Value).ToHashSet();
  }
}
