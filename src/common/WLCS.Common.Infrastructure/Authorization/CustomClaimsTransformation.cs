// <copyright file="CustomClaimsTransformation.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Authorization;

/// <summary>
/// Initializes a new instance of the <see cref="CustomClaimsTransformation"/> class.
/// </summary>
/// <param name="serviceScopeFactory">An instance of the service scope factory.</param>
internal sealed class CustomClaimsTransformation(IServiceScopeFactory serviceScopeFactory)
  : IClaimsTransformation
{
  private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

  /// <inheritdoc/>
  public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
  {
    if (principal.HasClaim(c => c.Type == CustomClaims.Sub))
    {
      return principal;
    }

    using var scope = _serviceScopeFactory.CreateScope();

    var permissionsService = scope.ServiceProvider.GetRequiredService<IPermissionService>();

    var identityId = principal.GetIdentityId();

    var result = await permissionsService.GetUserPermissionsAsync(identityId)
      .ConfigureAwait(false);

    if (result.IsFailure)
    {
      throw new WLCSException(nameof(IPermissionService.GetUserPermissionsAsync), result.Error);
    }

    var claimsIdentity = new ClaimsIdentity();

    claimsIdentity.AddClaim(new Claim(CustomClaims.Sub, result.Value.UserId.ToString()));

    foreach (var permission in result.Value.Permissions)
    {
      claimsIdentity.AddClaim(new Claim(CustomClaims.Permission, permission));
    }

    principal.AddIdentity(claimsIdentity);

    return principal;
  }
}
