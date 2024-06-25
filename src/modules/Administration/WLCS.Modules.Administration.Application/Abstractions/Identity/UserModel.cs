// <copyright file="UserModel.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Abstractions.Identity;

/// <summary>
/// Represents a user to register.
/// </summary>
/// <param name="Email">The email.</param>
/// <param name="Password">The password.</param>
/// <param name="FirstName">The first name.</param>
/// <param name="LastName">The last name.</param>
public sealed record UserModel(string Email, string Password, string FirstName, string LastName);
