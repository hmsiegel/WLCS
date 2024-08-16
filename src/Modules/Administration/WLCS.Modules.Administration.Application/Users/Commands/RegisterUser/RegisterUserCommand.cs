// <copyright file="RegisterUserCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(
  string Email,
  string Password,
  string FirstName,
  string LastName)
  : ICommand<Guid>;
