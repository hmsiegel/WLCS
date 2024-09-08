﻿// <copyright file="PermissionService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Authorization;

internal sealed class PermissionService(ISender sender) : IPermissionService
{
  private readonly ISender _sender = sender;

  public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
  {
    return await _sender.Send(new GetUserPermissionsQuery(identityId));
  }
}
