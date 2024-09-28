// <copyright file="CreateAthleteRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Contracts.Athletes;

public sealed record CreateAthleteRequest(
  string MembershipId,
  string FirstName,
  string LastName,
  DateOnly DateOfBirth,
  string Email,
  string Gender);
