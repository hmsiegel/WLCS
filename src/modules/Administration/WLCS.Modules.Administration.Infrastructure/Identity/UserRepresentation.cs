// <copyright file="UserRepresentation.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// Represents a new user.
/// </summary>
/// <param name="Username">The username.</param>
/// <param name="Email">The email address.</param>
/// <param name="FirstName">The first name.</param>
/// <param name="LastName">The last name.</param>
/// <param name="EmailVerified">Whether or not the email address has been verified.</param>
/// <param name="Enabled">Whether or not the user is enabled.</param>
/// <param name="Credentials">A list of credentials.</param>
internal sealed record UserRepresentation(
  string Username,
  string Email,
  string FirstName,
  string LastName,
  bool EmailVerified,
  bool Enabled,
  CredentialRepresentation[] Credentials);
