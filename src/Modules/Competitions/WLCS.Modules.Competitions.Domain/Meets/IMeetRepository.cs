// <copyright file="IMeetRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets;

public interface IMeetRepository
{
  void Add(Meet meet);

  Task<Meet?> GetAsync(Guid id, CancellationToken cancellationToken = default);

  Task<List<Meet>> GetAll(CancellationToken cancellationToken = default);
}
