// <copyright file="CompetitionRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Competitions;

internal sealed class CompetitionRepository(CompetitionsDbContext context) : ICompetitionRepository
{
  private readonly CompetitionsDbContext _context = context;

  public void Add(Competition competition)
  {
    _context.Competitions.Add(competition);
  }

  public void Update(Competition competition)
  {
    _context.Competitions.Update(competition);
  }

  public async Task<Competition?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var competition = await _context.Competitions.ToListAsync(cancellationToken);

    return competition.Find(competition => competition.Id.Value == id);
  }
}
