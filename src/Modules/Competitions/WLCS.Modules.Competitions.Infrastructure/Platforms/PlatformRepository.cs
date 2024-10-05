// <copyright file="PlatformRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Platforms;

internal sealed class PlatformRepository(CompetitionsDbContext dbContext) : IPlatformRepository
{
  private readonly CompetitionsDbContext _dbContext = dbContext;

  public void Add(Platform platform)
  {
    _dbContext.Platforms.Add(platform);
  }

  public void Update(Platform platform)
  {
    _dbContext.Platforms.Update(platform);
  }

  public async Task<IEnumerable<Platform>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _dbContext.Platforms.ToListAsync(cancellationToken);
  }

  public async Task<Platform?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var platforms = await _dbContext.Platforms.ToListAsync(cancellationToken);
    var platform = platforms.Find(p => p.Id.Value == id);
    return platform;
  }

  public async Task<IEnumerable<Platform>> GetByMeetId(Guid meetId, CancellationToken cancellationToken = default)
  {
    return await _dbContext.Platforms.Where(p => p.MeetId.Value == meetId).ToListAsync(cancellationToken);
  }
}
