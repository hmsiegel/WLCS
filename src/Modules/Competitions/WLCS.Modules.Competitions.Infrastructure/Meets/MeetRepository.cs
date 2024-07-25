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
}
