// <copyright file="IdentityProviderErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Abstractions.Identity;

public static class IdentityProviderErrors
{
  public static readonly Error EmailIsNotUnique = Error.Conflict(
    "Identity.EmailIsNotUnique",
    "The specified email is not unique.");
}
