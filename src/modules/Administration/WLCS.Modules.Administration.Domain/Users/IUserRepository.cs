// <copyright file="IUserRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

/// <summary>
/// A repository for managing <see cref="User"/> entities.
/// </summary>
public interface IUserRepository
{
  /// <summary>
  /// Gets a user by their ID.
  /// </summary>
  /// <param name="id">The id of the user.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The user.</returns>
  Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Adds a user to the repository.
  /// </summary>
  /// <param name="user">The user to add.</param>
  void Add(User user);
}
