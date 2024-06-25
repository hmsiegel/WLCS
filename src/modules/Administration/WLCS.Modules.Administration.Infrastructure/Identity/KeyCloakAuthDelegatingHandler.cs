// <copyright file="KeyCloakAuthDelegatingHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// Initializes a new instance of the <see cref="KeyCloakAuthDelegatingHandler"/> class.
/// </summary>
/// <param name="options">The key cloak options to inject.</param>
internal sealed class KeyCloakAuthDelegatingHandler(IOptions<KeyCloakOptions> options) : DelegatingHandler
{
  private readonly KeyCloakOptions _options = options.Value;

  /// <inheritdoc/>
  protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    var authToken = await GetAuthorizationTokenAsync(cancellationToken)
      .ConfigureAwait(false);

    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken.AccessToken);

    var httpResponseMessage = await base.SendAsync(request, cancellationToken)
      .ConfigureAwait(false);

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

    using HttpResponseMessage authResponse = await base.SendAsync(authRequest, cancellationToken)
      .ConfigureAwait(false);

    authResponse.EnsureSuccessStatusCode();

    return await authResponse.Content.ReadFromJsonAsync<AuthToken>(cancellationToken: cancellationToken)
      .ConfigureAwait(false) ?? throw new NotFoundException("Authentication token not found.");
  }

  /// <summary>
  /// Represents the authentication token.
  /// </summary>
  internal sealed class AuthToken
  {
    /// <summary>
    /// Gets the access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; } = string.Empty;
  }
}
