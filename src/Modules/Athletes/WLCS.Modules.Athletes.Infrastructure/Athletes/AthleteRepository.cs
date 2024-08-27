// <copyright file="AthleteRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Athletes;

internal sealed class AthleteRepository(AthletesDbContext dbContext) : IAthleteRepository
{
  private readonly AthletesDbContext _dbContext = dbContext;

  public void Add(Athlete athlete)
  {
    _dbContext.Athletes.Add(athlete);
  }

  public Task<bool> AthleteExistsAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return _dbContext.Athletes.AnyAsync(x => x.Id.Value == id, cancellationToken);
  }

  public Task<bool> AthleteExistsAsync(string memberId, CancellationToken cancellationToken = default)
  {
    return _dbContext.Athletes.AnyAsync(x => x.Membership.MembershipId == memberId, cancellationToken);
  }

  public async Task<Athlete?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _dbContext.Athletes.SingleOrDefaultAsync(x => x.Id.Value == id, cancellationToken);
  }

  public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default)
  {
    return !await _dbContext.Athletes.AnyAsync(x => x.Email == email, cancellationToken);
  }

  public async Task<IEnumerable<Athlete?>> ListAthletes(CancellationToken cancellationToken = default)
  {
    return await _dbContext.Athletes.ToListAsync(cancellationToken);
  }
}
