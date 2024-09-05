// <copyright file="UserRepresentation.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

internal sealed record UserRepresentation(
  string Username,
  string Email,
  string FirstName,
  string LastName,
  bool EmailVerified,
  bool Enabled,
  CredentialRepresentation[] Credentials);
