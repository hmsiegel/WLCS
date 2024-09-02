// <copyright file="ICompetitionRespository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public interface ICompetitionRespository
{
  void Add(Competition competition);

  void Update(Competition competition);

  Task<Competition?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
