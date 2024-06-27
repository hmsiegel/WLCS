// <copyright file="GetUserPermissionsQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.GetUserPermissions;

/// <summary>
/// Get user permissions query.
/// </summary>
/// <param name="IdentityId">The Identity Id of the user.</param>
public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionResponse>;
