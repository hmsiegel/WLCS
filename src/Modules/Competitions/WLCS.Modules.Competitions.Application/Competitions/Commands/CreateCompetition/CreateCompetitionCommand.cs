// <copyright file="CreateCompetitionCommand.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Common.Application.Messaging;

namespace WLCS.Modules.Competitions.Application.Competitions.Commands.CreateCompetition;

public sealed record CreateCompetitionCommand(
  Guid MeetId,
  string Name,
  Scope Scope,
  CompetitionType CompetitionType,
  AgeDivision AgeDivision) : ICommand<Guid>;
