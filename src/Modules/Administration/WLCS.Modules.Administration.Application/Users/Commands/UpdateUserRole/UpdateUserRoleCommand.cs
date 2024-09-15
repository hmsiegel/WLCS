// <copyright file="UpdateUserRoleCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUserRole;

public sealed record UpdateUserRoleCommand(Guid UserId, string UserRole) : ICommand;
