namespace Authorization.AuthorizationHandlers;

/// <summary>
/// Represents the <see cref="PermissionAuthorizationHandler"/> class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PermissionAuthorizationHandler"/> class.
/// </remarks>
/// <param name="serviceScopeFactory">The service scope factory.</param>
internal sealed class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirement>
{
    /// <inheritdoc/>
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        using IServiceScope scope = serviceScopeFactory.CreateScope();

        var permissionService = scope.ServiceProvider.GetService<IPermissionService>()!;

        var permissions = await permissionService.GetPermissionsAsync(context.User.GetIdentityProviderId());

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
