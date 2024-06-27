// <copyright file="PermissionAuthorizationHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

/// <summary>
/// Handles the authorization of permissions.
/// </summary>
internal sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
  /// <inheritdoc/>
  protected override Task HandleRequirementAsync(
    AuthorizationHandlerContext context,
    PermissionRequirement requirement)
  {
    var permissions = context.User.GetPermissions();

    if (permissions.Contains(requirement.Perission))
    {
      context.Succeed(requirement);
    }

    return Task.CompletedTask;
  }
}
