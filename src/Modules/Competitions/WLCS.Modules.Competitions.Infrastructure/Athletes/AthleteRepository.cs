// <copyright file="AthleteRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Athletes;

internal sealed class AthleteRepository(CompetitionsDbContext dbContext) : IAthleteRepository
{
  private readonly CompetitionsDbContext _dbContext = dbContext;

  public void Add(Athlete athlete)
  {
    _dbContext.Athletes.Add(athlete);
  }

  public void Update(Athlete athlete)
  {
    _dbContext.Athletes.Update(athlete);
  }

  public async Task<Athlete?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _dbContext.Athletes.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
  }
}
