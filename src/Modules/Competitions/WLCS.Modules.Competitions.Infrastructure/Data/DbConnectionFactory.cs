// <copyright file="DbConnectionFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
  private readonly NpgsqlDataSource _dataSource = dataSource;

  public async ValueTask<DbConnection> OpenConnectionAsync()
  {
    return await _dataSource.OpenConnectionAsync();
  }
}
