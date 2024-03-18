namespace Authorization.Services;

/// <summary>
/// Represents the permission service.
/// </summary>
internal sealed class PermissionService : IPermissionService
{
    private readonly IRequestClient<IUserPermissionsRequest> _requestClient;
    private readonly IMemoryCache _cache;
    private readonly PermissionAuthorizationOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionService"/> class.
    /// </summary>
    /// <param name="requestClient">The user permissions request.</param>
    /// <param name="cache">The memory cache.</param>
    /// <param name="options">The options.</param>
    public PermissionService(
        IRequestClient<IUserPermissionsRequest> requestClient,
        IMemoryCache cache,
        IOptions<PermissionAuthorizationOptions> options)
    {
        _requestClient = requestClient;
        _cache = cache;
        _options = options.Value;
    }

    /// <inheritdoc/>
    public async Task<HashSet<string>> GetPermissionsAsync(
        string identityProviderId,
        CancellationToken cancellationToken = default)
    {
        return await _cache.GetOrCreateAsync(
            CreateCacheKey(identityProviderId),
            async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_options.CacheTimeInMinutes);
                return await GetPermissionsInternalAsync(identityProviderId, cancellationToken);
            });
    }

    private async Task<HashSet<string>> GetPermissionsInternalAsync(string identityProviderId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(identityProviderId))
        {
            return [];
        }

        var request = new UserPermissionRequest
        {
            UserIdentityProviderId = identityProviderId,
        };

        var response = await _requestClient.GetResponse<IUserPermissionsResponse>(request, cancellationToken);

        return response.Message.Permissions;
    }

    private string CreateCacheKey(string identityProviderId) => $"{_options.CacheKeyPrefix}{identityProviderId}";

    private sealed class UserPermissionRequest : IUserPermissionsRequest
    {
        public string UserIdentityProviderId { get; init; } = string.Empty;
    }
}

