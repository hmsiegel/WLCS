// <copyright file="IUnitOfWork.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Application.Abstractions.Data;

/// <summary>
/// Represents the unit of work for the Competition module.
/// </summary>
public interface IUnitOfWork
{
  /// <summary>
  /// Saves the changes.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The return code.</returns>
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
