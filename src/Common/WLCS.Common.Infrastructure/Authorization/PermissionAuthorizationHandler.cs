// <copyright file="PermissionAuthorizationHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
  protected override Task HandleRequirementAsync(
    AuthorizationHandlerContext context,
    PermissionRequirement requirement)
  {
    HashSet<string> permissions = context.User.GetPermissions();

    if (permissions.Contains(requirement.Permission))
    {
      context.Succeed(requirement);
    }

    return Task.CompletedTask;
  }
}
