// <copyright file="ICacheService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Caching;

/// <summary>
/// Services for caching.
/// </summary>
public interface ICacheService
{
  /// <summary>
  /// Gets the value from the cache.
  /// </summary>
  /// <typeparam name="T">The type of the value that we are getting.</typeparam>
  /// <param name="key">The key.</param>
  /// <param name="cancellationToken">The canceallation token.</param>
  /// <returns>The same type.</returns>
  Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

  /// <summary>
  /// Removes the value from the cache.
  /// </summary>
  /// <param name="key">The key.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A task.</returns>
  Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
