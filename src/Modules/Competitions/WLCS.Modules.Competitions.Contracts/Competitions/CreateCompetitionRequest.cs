// <copyright file="CreateCompetitionRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Competitions;

public sealed record CreateCompetitionRequest(
  string Name,
  string Scope,
  string CompetitionType,
  string AgeDivision);
