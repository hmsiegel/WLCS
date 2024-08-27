// <copyright file="RegisterAthleteRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Presentation.Athletes;

internal sealed record RegisterAthleteRequest(
  string MembershipId,
  string FirstName,
  string LastName,
  DateOnly DateOfBirth,
  string Email,
  string Gender);
