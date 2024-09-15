// <copyright file="ListRolesQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Queries.ListRoles;

public sealed record ListRolesQuery() : IQuery<List<RoleResponse>>;
