// <copyright file="PermissionRequirement.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

/// <summary>
/// Represents the permission requirement.
/// </summary>
internal sealed class PermissionRequirement : IAuthorizationRequirement
{
  /// <summary>
  /// Initializes a new instance of the <see cref="PermissionRequirement"/> class.
  /// </summary>
  /// <param name="perission">The permission.</param>
  public PermissionRequirement(string perission)
  {
    Perission = perission;
  }

  /// <summary>
  /// Gets the permission.
  /// </summary>
  public string Perission { get; } = string.Empty;
}
