namespace Modules.Users.Infrastructure.Authorization.SameUser.AuthorizationHandlers;

/// <summary>
/// Represents the <see cref="SameUserRequirement"/> authorization handler.
/// </summary>
internal sealed class SameUserAuthorizationHandler : AuthorizationHandler<SameUserRequirement>
{
    private const string _userIdResourceName = "userId";
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="SameUserAuthorizationHandler"/> class.
    /// </summary>
    /// <param name="serviceScopeFactory">The service scope factory.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public SameUserAuthorizationHandler(IServiceScopeFactory serviceScopeFactory, IHttpContextAccessor httpContextAccessor)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement)
    {
        if (!TryGetUserIdentifiers(out (DefaultIdType UserId, string IdentityProviderId) userIdentifiers))
        {
            return;
        }

        using IServiceScope scope = _serviceScopeFactory.CreateScope();

        IUserChecker userChecker = scope.ServiceProvider.GetService<IUserChecker>()!;

        if (await userChecker.ExistsAsync(userIdentifiers.UserId, userIdentifiers.IdentityProviderId).ConfigureAwait(false))
        {
            context.Succeed(requirement);
        }
    }

    private bool TryGetUserIdentifiers(out (DefaultIdType UserId, string IdentityProviderId) userIdentifiers)
    {
        var identityProviderId = _httpContextAccessor.HttpContext?.User.GetIdentityProviderId();

        var userIdFromRoute = GetUserIdFromRoute();

        if (identityProviderId is null || userIdFromRoute is null)
        {
            userIdentifiers = (DefaultIdType.Empty, string.Empty);

            return false;
        }

        userIdentifiers = (userIdFromRoute.Value, identityProviderId);

        return true;
    }

    private DefaultIdType? GetUserIdFromRoute()
    {
        var routeValueDictionary = _httpContextAccessor.HttpContext?.GetRouteData().Values;

        if (routeValueDictionary is null ||
            !routeValueDictionary.TryGetValue(_userIdResourceName, out object? userIdValue) ||
            !DefaultIdType.TryParse(userIdValue?.ToString(), out DefaultIdType userId))
        {
            return null;
        }

        return userId;
    }
}
