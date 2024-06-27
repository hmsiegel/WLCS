// <copyright file="PermissionResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Authorization;

/// <summary>
/// Represents a user's permissions.
/// </summary>
/// <param name="UserId">The user Id of the user.</param>
/// <param name="Permissions">The permissions of the user.</param>
public sealed record PermissionResponse(Guid UserId, HashSet<string> Permissions);
