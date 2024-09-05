// <copyright file="UserModel.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Abstractions.Identity;

public sealed record class UserModel(
  string Email,
  string Password,
  string FirstName,
  string LastName);
