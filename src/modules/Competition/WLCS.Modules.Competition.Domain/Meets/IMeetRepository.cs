// <copyright file="IMeetRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Domain.Meets;

/// <summary>
/// Represents a meet repository.
/// </summary>
public interface IMeetRepository
{
  /// <summary>
  /// Adds a meet to the repository.
  /// </summary>
  /// <param name="meet">The meet to add.</param>
  void Add(Meet meet);

  /// <summary>
  /// Gets a meet by the unique identifier.
  /// </summary>
  /// <param name="id">The unique identifer.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The meet.</returns>
  Task<Meet?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets all meets.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A list of all of the meets..</returns>
  Task<List<Meet>> GetAll(CancellationToken cancellationToken = default);
}
