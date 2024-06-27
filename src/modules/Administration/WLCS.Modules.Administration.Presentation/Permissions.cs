// <copyright file="Permissions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Presentation;

/// <summary>
/// Represents the permissions for the Administration module.
/// </summary>
internal static class Permissions
{
  /// <summary>
  /// The permission to get a user.
  /// </summary>
  internal const string GetUser = "users:read";

  /// <summary>
  /// The permission to update a user's profile.
  /// </summary>
  internal const string ModifyUser = "users:update";
}
