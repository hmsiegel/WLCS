namespace Authorization.AuthorizationPolicyProviders;

/// <summary>
/// Represents the permission authorization policy provider.
/// </summary>
/// <summary>
/// Initializes a new instance of the <see cref="PermissionAuthorizationPolicyProvider"/> class.
/// </summary>
/// <param name="options">The authorization options.</param>
internal sealed class PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    : DefaultAuthorizationPolicyProvider(options)
{
    /// <inheritdoc/>
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var authorizationPolicy = await base.GetPolicyAsync(policyName).ConfigureAwait(false);

        if (authorizationPolicy is not null)
        {
            return authorizationPolicy;
        }

        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();
    }
}
