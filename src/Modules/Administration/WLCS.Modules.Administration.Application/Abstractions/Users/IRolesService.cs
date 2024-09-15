// <copyright file="IRolesService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Abstractions.Users;

public interface IRolesService
{
  Task<Result> AddRole(Guid userId, string roleName, CancellationToken cancellationToken = default);

  Task<Result> RemoveRole(Guid userId, string roleName, CancellationToken cancellationToken = default);

  Task<Result> UpdateRole(Guid userId, string roleName, CancellationToken cancellationToken = default);
}
