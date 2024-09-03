// <copyright file="UpdateAthleteCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Athletes.Commands.UpdateAthlete;

public sealed record UpdateAthleteCommand(
    Guid AthleteId,
    string FirstName,
    string LastName,
    string Club,
    string Coach)
  : ICommand;
