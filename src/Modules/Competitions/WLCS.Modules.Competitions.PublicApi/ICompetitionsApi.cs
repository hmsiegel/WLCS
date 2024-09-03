// <copyright file="ICompetitionsApi.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.PublicApi;

public interface ICompetitionsApi
{
  Task CreateAthleteAsync(
    Guid athleteId,
    string membership,
    string firstName,
    string lastName,
    DateOnly dateOfBirth,
    string gender,
    CancellationToken cancellationToken = default);
}
