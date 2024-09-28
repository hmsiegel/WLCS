// <copyright file="RegisterUserRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Contracts.Users;

public sealed record RegisterUserRequest(
  string Email,
  string Password,
  string FirstName,
  string LastName);
