// <copyright file="IAthleteRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes;

public interface IAthleteRepository
{
  Task<Athlete?> GetAsync(Guid id, CancellationToken cancellationToken = default);

  Task<IEnumerable<Athlete?>> ListAthletes(CancellationToken cancellationToken = default);

  Task<bool> AthleteExistsAsync(Guid id, CancellationToken cancellationToken = default);

  Task<bool> AthleteExistsAsync(string memberId, CancellationToken cancellationToken = default);

  Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);

  void Add(Athlete athlete);
}
