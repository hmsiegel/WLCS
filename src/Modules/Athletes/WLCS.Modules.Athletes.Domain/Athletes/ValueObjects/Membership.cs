// <copyright file="Membership.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.ValueObjects;

public sealed record Membership(string MembershipId, DateTime? ExpirationDate)
{
  public static Result<Membership> Create(string membershipId, DateTime? expirationDate)
  {
    if (string.IsNullOrWhiteSpace(membershipId))
    {
      return Result.Failure<Membership>(MembershipErrors.IdCannotBeEmpty);
    }

    return Result.Success(new Membership(membershipId, expirationDate));
  }

  public static Result<Membership> Create(string membershipId)
  {
    return Create(membershipId, null);
  }
}
