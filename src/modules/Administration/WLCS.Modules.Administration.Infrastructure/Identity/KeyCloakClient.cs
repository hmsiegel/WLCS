// <copyright file="KeyCloakClient.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// Represents the <see cref="KeyCloakClient"/> class.
/// </summary>
/// <param name="httpClient">And instance of HttpClient.</param>
internal sealed class KeyCloakClient(HttpClient httpClient)
{
  private readonly HttpClient _httpClient = httpClient;

  /// <summary>
  /// Registers a user in the identity provider.
  /// </summary>
  /// <param name="user">The user to register.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>The ID of the created user.</returns>
  internal async Task<string> RegisterUserAsync(
    UserRepresentation user,
    CancellationToken cancellationToken = default)
  {
    var httpResponseMessage = await _httpClient.PostAsJsonAsync(
        "users",
        user,
        cancellationToken)
      .ConfigureAwait(false);

    httpResponseMessage.EnsureSuccessStatusCode();

    return ExtractIdentityIdFromLocationHeader(httpResponseMessage);
  }

  private static string ExtractIdentityIdFromLocationHeader(
      HttpResponseMessage httpResponseMessage)
  {
    const string usersSegmentName = "users/";

    var locationHeader =
      httpResponseMessage.Headers.Location?.PathAndQuery
      ?? throw new InvalidOperationException("Location header is null");

    var userSegmentValueIndex = locationHeader.IndexOf(
        usersSegmentName,
        StringComparison.InvariantCultureIgnoreCase);

    var identityId = locationHeader[(userSegmentValueIndex + usersSegmentName.Length)..];

    return identityId;
  }
}
