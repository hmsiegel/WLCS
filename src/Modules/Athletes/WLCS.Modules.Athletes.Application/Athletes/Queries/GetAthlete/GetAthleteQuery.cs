// <copyright file="GetAthleteQuery.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application.Athletes.Queries.GetAthlete;

public sealed record GetAthleteQuery(Guid AthleteId) : IQuery<AthleteResponse>;
