// <copyright file="PermissionRequirement.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

internal sealed class PermissionRequirement : IAuthorizationRequirement
{
  public PermissionRequirement(string permission)
  {
    Permission = permission;
  }

  public string Permission { get; }
}
