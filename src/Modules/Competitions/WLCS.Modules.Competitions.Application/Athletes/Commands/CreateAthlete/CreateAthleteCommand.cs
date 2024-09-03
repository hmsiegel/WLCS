// <copyright file="CreateAthleteCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.CreateAthlete;

public sealed record CreateAthleteCommand(
  Guid Id,
  string Membership,
  string FirstName,
  string LastName,
  DateOnly DateOfBirth,
  string Gender) : ICommand;
