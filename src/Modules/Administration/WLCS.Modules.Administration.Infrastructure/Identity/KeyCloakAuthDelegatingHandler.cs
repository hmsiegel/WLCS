// <copyright file="KeyCloakAuthDelegatingHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

internal sealed class KeyCloakAuthDelegatingHandler(IOptions<KeyCloakOptions> options) : DelegatingHandler
{
  private readonly KeyCloakOptions _options = options.Value;

  protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    var authorizationToken = await GetAuthorizationTokenAsync(cancellationToken);

    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authorizationToken.AccessToken);

    var httpResponseMessage = await base.SendAsync(request, cancellationToken);

    httpResponseMessage.EnsureSuccessStatusCode();

    return httpResponseMessage;
  }

  private async Task<AuthToken> GetAuthorizationTokenAsync(CancellationToken cancellationToken)
  {
    var authRequestParameters = new KeyValuePair<string, string>[]
    {
      new("client_id", _options.ConfidentialClientId),
      new("client_secret", _options.ConfidentialClientSecret),
      new("scope", "openid"),
      new("grant_type", "client_credentials"),
    };

    using var authRequestContent = new FormUrlEncodedContent(authRequestParameters);

    using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_options.TokenUrl));

    authRequest.Content = authRequestContent;

    using HttpResponseMessage authResponse = await base.SendAsync(authRequest, cancellationToken);

    authResponse.EnsureSuccessStatusCode();

    var result = await authResponse.Content.ReadFromJsonAsync<AuthToken>(cancellationToken);

    return result!;
  }

  internal sealed class AuthToken
  {
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; } = default!;
  }
}
