// <copyright file="IdentityProviderErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Abstractions.Identity;

/// <summary>
/// Represents the <see cref="IdentityProviderErrors"/> class.
/// </summary>
public static class IdentityProviderErrors
{
  /// <summary>
  /// Represents an error indicating that the user's email is not unique.
  /// </summary>
  public static readonly Error EmailIsNotUnqiue = Error.Conflict(
    "Identity.EmailIsNotUnique",
    "The spcified email is already in use.");
}
