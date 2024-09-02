// <copyright file="AthleteResponse.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Queries.GetAthlete;

public sealed record AthleteResponse(
  Guid Id,
  string MembershipId,
  string FirstName,
  string LastName,
  string Email,
  string Gender,
  DateOnly DateOfBirth);
