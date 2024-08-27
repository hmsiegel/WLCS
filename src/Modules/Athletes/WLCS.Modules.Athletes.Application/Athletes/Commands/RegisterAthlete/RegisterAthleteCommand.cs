// <copyright file="RegisterAthleteCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Commands.RegisterAthlete;

public sealed record RegisterAthleteCommand(
    string MembershipId,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string Gender)
  : ICommand<Guid>;
