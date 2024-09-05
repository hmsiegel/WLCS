// <copyright file="KeyCloakClient.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

internal sealed class KeyCloakClient(HttpClient httpClient)
{
  private readonly HttpClient _httpClient = httpClient;

  internal async Task<string> RegisterUserAsync(UserRepresentation user, CancellationToken cancellationToken = default)
  {
    var httpResponseMessage = await _httpClient.PostAsJsonAsync(
      "users",
      user,
      cancellationToken);

    httpResponseMessage.EnsureSuccessStatusCode();

    return ExtractIdentityIdFromLocationHeader(httpResponseMessage);
  }

  private static string ExtractIdentityIdFromLocationHeader(HttpResponseMessage response)
  {
    const string usersSegmentName = "users/";

    var locationHeader = response.Headers.Location?.PathAndQuery ?? throw new InvalidOperationException("Location header is missing.");

    var userSegmentValueIndex = locationHeader.IndexOf(usersSegmentName, StringComparison.InvariantCultureIgnoreCase);

    var identityId = locationHeader[(userSegmentValueIndex + usersSegmentName.Length)..];

    return identityId;
  }
}
