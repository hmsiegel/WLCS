namespace Modules.Users.Infrastructure.Authorization.SameUser.Services;

/// <summary>
/// Represents the user checker service.
/// </summary>
internal sealed class UserChecker : IUserChecker
{
    private readonly ISqlQueryExecutor _sqlQueryExecutor;
    private readonly IMemoryCache _memoryCache;
    private readonly SameUserAuthorizationOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserChecker"/> class.
    /// </summary>
    /// <param name="sqlQueryExecutor">The SQL query executor.</param>
    /// <param name="memoryCache">The memory cache.</param>
    /// <param name="options">The options.</param>
    public UserChecker(ISqlQueryExecutor sqlQueryExecutor, IMemoryCache memoryCache, IOptions<SameUserAuthorizationOptions> options)
    {
        _sqlQueryExecutor = sqlQueryExecutor;
        _memoryCache = memoryCache;
        _options = options.Value;
    }

    /// <inheritdoc/>
    public async Task<bool> ExistsAsync(DefaultIdType userId, string identityProviderId, CancellationToken cancellationToken = default)
    {
        return await _memoryCache.GetOrCreateAsync(
            CreateCacheKey(userId, identityProviderId),
            async entry =>
               {
                   entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_options.CacheTimeInMinutes);
                   return await ExistsInternalAsync(userId, identityProviderId).ConfigureAwait(false);
               }).ConfigureAwait(false);
    }

    private string CreateCacheKey(DefaultIdType userId, string identityProviderId)
    {
        return $"{_options.CacheKeyPrefix}{userId}-{identityProviderId}";
    }

    private async Task<bool> ExistsInternalAsync(DefaultIdType userId, string identityProviderId)
    {
        const string sql = @"
            SELECT EXISTS(
                SELECT 1
                FROM users.users
                WHERE id = @UserId
                AND identity_provider_id = @IdentityProviderId
            )";

        return await _sqlQueryExecutor.ExecuteScalarAsync<bool>(
            sql,
            new
            {
                UserId = userId,
                IdentityProviderId = identityProviderId,
            }).ConfigureAwait(false);
    }
}
