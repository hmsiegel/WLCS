// <copyright file="CompetitionRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Competitions;

public sealed record CompetitionRequest(
  string Name,
  string Scope,
  string CompetitionType,
  string AgeDivision);
