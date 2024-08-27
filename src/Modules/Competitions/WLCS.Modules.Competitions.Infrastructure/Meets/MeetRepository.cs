// <copyright file="MeetRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Meets;

internal sealed class MeetRepository(CompetitionsDbContext context) : IMeetRepository
{
  private readonly CompetitionsDbContext _context = context;

  public void Add(Meet meet)
  {
    _context.Meets.Add(meet);
  }

  public async Task<List<Meet>> GetAll(CancellationToken cancellationToken = default)
  {
    return await _context.Meets.ToListAsync(cancellationToken);
  }

  public async Task<Meet?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var meets = await _context.Meets.ToListAsync(cancellationToken);
    var meet = meets.Find(m => m.Id.Value == id);

    return meet;
  }
}
