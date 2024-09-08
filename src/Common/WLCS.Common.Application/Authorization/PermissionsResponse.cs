// <copyright file="PermissionsResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Authorization;

public sealed record PermissionsResponse(Guid UserId, HashSet<string> Permissions);
