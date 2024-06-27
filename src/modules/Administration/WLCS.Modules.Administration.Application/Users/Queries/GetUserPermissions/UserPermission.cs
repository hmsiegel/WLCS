// <copyright file="UserPermission.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUserPermissions;

/// <summary>
/// Represents a user permission.
/// </summary>
internal sealed class UserPermission
{
  /// <summary>
  /// Gets the user id.
  /// </summary>
  internal Guid UserId { get; init; }

  /// <summary>
  /// Gets the permission.
  /// </summary>
  internal string Permission { get; init; } = string.Empty;
}
