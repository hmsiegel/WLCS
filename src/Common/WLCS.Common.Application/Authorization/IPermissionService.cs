// <copyright file="IPermissionService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Authorization;

public interface IPermissionService
{
  Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}
