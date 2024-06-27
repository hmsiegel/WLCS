// <copyright file="IUnitOfWork.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Scheduling.Application.Abstractions.Data;

/// <summary>
/// Represents the unit of work.
/// </summary>
public interface IUnitOfWork
{
  /// <summary>
  /// Saves the changes made to the database.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The return status code.</returns>
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
