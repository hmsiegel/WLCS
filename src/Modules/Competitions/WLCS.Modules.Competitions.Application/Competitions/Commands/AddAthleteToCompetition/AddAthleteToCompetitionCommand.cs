// <copyright file="AddAthleteToCompetitionCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.AddAthleteToCompetition;

public sealed record AddAthleteToCompetitionCommand(
  Guid AthleteId,
  Guid CompetitionId)
  : ICommand;
