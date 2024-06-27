// <copyright file="PermissionAuthorizationPolicyProvider.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

/// <summary>
/// The permission authorization policy provider.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PermissionAuthorizationPolicyProvider"/> class.
/// </remarks>
/// <param name="options">Authorization options.</param>
internal sealed class PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
  : DefaultAuthorizationPolicyProvider(options)
{
  private readonly AuthorizationOptions _options = options.Value;

  /// <inheritdoc/>
  public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
  {
    var policy = await base.GetPolicyAsync(policyName)
      .ConfigureAwait(false);

    if (policy is not null)
    {
      return policy;
    }

    var permissionPolicy = new AuthorizationPolicyBuilder()
      .AddRequirements(new PermissionRequirement(policyName))
      .Build();

    _options.AddPolicy(policyName, permissionPolicy);

    return permissionPolicy;
  }
}
