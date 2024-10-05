// <copyright file="UpdateCompetitionCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.UpdateCompetition;

public sealed record UpdateCompetitionCommand(
  Guid CompetitionId,
  string Name,
  string Scope,
  string CompetitionType,
  string AgeDivision) : ICommand;
