// <copyright file="IDbConnectionFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
  ValueTask<DbConnection> OpenConnectionAsync();
}
