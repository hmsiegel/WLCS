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
}
