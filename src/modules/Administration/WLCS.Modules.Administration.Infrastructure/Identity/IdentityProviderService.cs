// <copyright file="IdentityProviderService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// Represents the <see cref="IdentityProviderService"/> class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="IdentityProviderService"/> class.
/// </remarks>
/// <param name="keyCloakClient">An instance of the KeyCloakClient.</param>
internal sealed class IdentityProviderService(
  KeyCloakClient keyCloakClient)
  : IIdentityProviderService
{
  private const string PasswordCredentialType = "Password";

  private readonly KeyCloakClient _keyCloakClient = keyCloakClient;

  /// <inheritdoc/>
  public async Task<Result<string>> RegisterUserAsync(UserModel usermodel, CancellationToken cancellationToken = default)
  {
    var userRepresentation = new UserRepresentation(
      usermodel.Email,
      usermodel.Email,
      usermodel.FirstName,
      usermodel.LastName,
      true,
      true,
      [new CredentialRepresentation(PasswordCredentialType, usermodel.Password, false)]);

    try
    {
      var identityId = await _keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken)
        .ConfigureAwait(false);

      return identityId;
    }
    catch (HttpRequestException exception) when (exception.StatusCode == HttpStatusCode.Conflict)
    {
      LoggerMessage.Define(
        LogLevel.Error,
        new EventId(1, "UserRegistrationFailed"),
        "User registration failed.");

      return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnqiue);
    }
  }
}
