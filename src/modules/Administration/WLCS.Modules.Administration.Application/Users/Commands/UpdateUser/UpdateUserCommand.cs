// <copyright file="UpdateUserCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.UpdateUser;

/// <summary>
/// Updates a user.
/// </summary>
/// <param name="UserId">The Id of the user.</param>
/// <param name="FirstName">The updated first name.</param>
/// <param name="LastName">The updated last name.</param>
public sealed record UpdateUserCommand(
  Guid UserId,
  string FirstName,
  string LastName) : ICommand;
