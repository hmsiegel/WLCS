// <copyright file="DbConnectionFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Infrastructure.Data;

/// <summary>
/// The database connection factory.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DbConnectionFactory"/> class.
/// </remarks>
/// <param name="dataSource">The data source.</param>
internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
  private readonly NpgsqlDataSource _dataSource = dataSource;

  /// <inheritdoc/>
  public async ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
  {
    return await _dataSource.OpenConnectionAsync(cancellationToken).ConfigureAwait(false);
  }
}
