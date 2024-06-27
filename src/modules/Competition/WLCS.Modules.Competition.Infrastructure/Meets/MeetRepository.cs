// <copyright file="MeetRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Infrastructure.Meets;

/// <summary>
/// The meet repository.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MeetRepository"/> class.
/// </remarks>
/// <param name="dbContext">The database context.</param>
internal sealed class MeetRepository(CompetitionsDbContext dbContext) : IMeetRepository
{
  private readonly CompetitionsDbContext _dbContext = dbContext;

  /// <inheritdoc/>
  public void Add(Meet meet)
  {
    _dbContext.Meets.Add(meet);
  }

  /// <inheritdoc/>
  public async Task<List<Meet>> GetAll(CancellationToken cancellationToken = default)
  {
    return await _dbContext.Meets.ToListAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<Meet?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _dbContext.Meets.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
  }
}
