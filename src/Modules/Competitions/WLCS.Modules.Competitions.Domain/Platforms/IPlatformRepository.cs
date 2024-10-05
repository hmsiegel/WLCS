// <copyright file="IPlatformRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Platforms;

public interface IPlatformRepository
{
  void Add(Platform platform);

  void Update(Platform platform);

  Task<Platform?> GetAsync(Guid id, CancellationToken cancellationToken = default);

  Task<IEnumerable<Platform>> GetAllAsync(CancellationToken cancellationToken = default);

  Task<IEnumerable<Platform>> GetByMeetId(Guid meetId, CancellationToken cancellationToken = default);
}
