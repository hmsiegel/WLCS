// <copyright file="CreateCompetitionRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation.Competitions;

internal sealed record CreateCompetitionRequest(
  Guid MeetId,
  string Name,
  string Scope,
  string CompetitionType,
  string AgeDivision);
