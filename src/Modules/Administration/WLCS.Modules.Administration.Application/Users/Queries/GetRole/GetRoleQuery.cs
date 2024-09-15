// <copyright file="GetRoleQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Administration.Application.Users.Queries.ListRoles;

namespace WLCS.Modules.Administration.Application.Users.Queries.GetRole;

public sealed record GetRoleQuery(string Name) : IQuery<RoleResponse>;
