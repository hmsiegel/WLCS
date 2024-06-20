// <copyright file="CacheService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using System.Text.Json;
using WLCS.Common.Application.Caching;

namespace WLCS.Common.Infrastructure.Caching;

/// <summary>
/// Initializes a new instance of the <see cref="CacheService"/> class.
/// </summary>
/// <param name="cache">The cache.</param>
internal sealed class CacheService(IDistributedCache cache) : ICacheService
{
  private readonly IDistributedCache _cache = cache;

  /// <inheritdoc/>
  public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
  {
    var bytes = await _cache.GetAsync(key, cancellationToken).ConfigureAwait(false);

    return bytes is null ? default : Deserialize<T>(bytes);
  }

  /// <inheritdoc/>
  public Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
    _cache.RemoveAsync(key, cancellationToken);

  /// <summary>
  /// Sets the cache.
  /// </summary>
  /// <typeparam name="T">The type.</typeparam>
  /// <param name="key">The key.</param>
  /// <param name="value">The value of the key.</param>
  /// <param name="expiration">The expiration of the cache.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A task.</returns>
  public Task SetAsync<T>(
    string key,
    T value,
    TimeSpan? expiration = null,
    CancellationToken cancellationToken = default)
  {
    var bytes = Serialize(value);

    return _cache.SetAsync(
      key,
      bytes,
      CacheOptions.Create(expiration),
      cancellationToken);
  }

  private static T Deserialize<T>(byte[] bytes)
  {
    return JsonSerializer.Deserialize<T>(bytes)!;
  }

  private static byte[] Serialize<T>(T? value)
  {
    throw new NotImplementedException();
  }
}
