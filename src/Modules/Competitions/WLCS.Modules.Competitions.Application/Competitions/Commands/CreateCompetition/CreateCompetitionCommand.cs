// <copyright file="CreateCompetitionCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.CreateCompetition;

public sealed record CreateCompetitionCommand(
  Guid MeetId,
  string Name,
  string Scope,
  string CompetitionType,
  string AgeDivision) : ICommand<Guid>;
