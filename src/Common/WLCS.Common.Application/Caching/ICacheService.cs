// <copyright file="ICacheService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Caching;

public interface ICacheService
{
  Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

  Task SetAsync<T>(
      string key,
      T value,
      TimeSpan? expiration = null,
      CancellationToken cancellationToken = default);

  Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
