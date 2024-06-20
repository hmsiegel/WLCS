// <copyright file="CacheOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Caching;

/// <summary>
/// Options for caching.
/// </summary>
public static class CacheOptions
{
  /// <summary>
  /// Gets the default expiration time for cache entries.
  /// </summary>
  public static DistributedCacheEntryOptions DefaultExpiration => new()
  {
    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2),
  };

  /// <summary>
  /// Create a new <see cref="DistributedCacheEntryOptions"/> with the specified expiration.
  /// </summary>
  /// <param name="expiration">The expiration time.</param>
  /// <returns>The distributed cache entry options.</returns>
  public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
    expiration is not null ?
      new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration }
      : DefaultExpiration;
}
