// <copyright file="IPermissionService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Authorization;

/// <summary>
/// A service to manage permissions.
/// </summary>
public interface IPermissionService
{
  /// <summary>
  /// Gets the permissions for the specified user.
  /// </summary>
  /// <param name="identityId">The identity of the user.</param>
  /// <returns>The user's permissions.</returns>
  Task<Result<PermissionResponse>> GetUserPermissionsAsync(string identityId);
}
