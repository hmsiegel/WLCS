// <copyright file="IAthleteRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Athletes;

public interface IAthleteRepository
{
  void Add(Athlete athlete);

  void Update(Athlete athlete);

  Task<Athlete?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
