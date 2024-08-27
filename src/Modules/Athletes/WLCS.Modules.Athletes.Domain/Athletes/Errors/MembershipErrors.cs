// <copyright file="MembershipErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.Errors;

public static class MembershipErrors
{
  public static Error IdCannotBeEmpty => Error.Problem(
    "Membership.IdCannotBeEmpty",
    "The Membership Id cannot be empty.");
}
