// <copyright file="IDbConnectionFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Data;

public interface IDbConnectionFactory
{
  ValueTask<DbConnection> OpenConnectionAsync();
}
