// <copyright file="AddAthleteToCompetitionRequest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Contracts.Competitions;

public sealed record AddAthleteToCompetitionRequest(Guid CompetitionId, Guid AthleteId);
