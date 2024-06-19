// <copyright file="IDbConnectionFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Data;

/// <summary>
/// Represents the database connection factory.
/// </summary>
public interface IDbConnectionFactory
{
  /// <summary>
  /// Opens a new database connection.
  /// </summary>
  /// <param name="cancellationToken">The cancellation.</param>
  /// <returns>The database connections.</returns>
  ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default);
}
