// <copyright file="IdentityProviderService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

internal sealed class IdentityProviderService(KeyCloakClient keyCloakClient, ILogger<IdentityProviderService> logger) : IIdentityProviderService
{
  private const string PasswordCredentialType = "Password";

  private readonly KeyCloakClient _keyCloakClient = keyCloakClient;
  private readonly ILogger<IdentityProviderService> _logger = logger;

  // POST /admin/realms/{realm}/users
  public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
  {
    var userRepresentation = new UserRepresentation(
      user.Email,
      user.Email,
      user.FirstName,
      user.LastName,
      true,
      true,
      [new CredentialRepresentation(
        PasswordCredentialType,
        user.Password,
        false)]);

    try
    {
      var identityId = await _keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);

      return identityId;
    }
    catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.Conflict)
    {
      _logger.UserRegistrationError(user.Email, exception);

      return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnique);
    }
  }
}
