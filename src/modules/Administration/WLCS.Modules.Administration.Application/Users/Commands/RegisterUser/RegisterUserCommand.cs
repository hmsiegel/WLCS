// <copyright file="RegisterUserCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

/// <summary>
/// A command to register a new user.
/// </summary>
/// <param name="Email">The user's email.</param>
/// <param name="Password">The user's password.</param>
/// <param name="FirstName">The user's first name.</param>
/// <param name="LastName">The user's last name.</param>
public sealed record RegisterUserCommand(
  string Email,
  string Password,
  string FirstName,
  string LastName)
  : ICommand<Guid>;
