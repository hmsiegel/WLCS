// <copyright file="BaseIntegrationTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Abstractions;

/// <summary>
/// Represents the base integration test.
/// </summary>
[Collection(nameof(IntegrationTestCollection))]
public class BaseIntegrationTest : IDisposable
{
  /// <summary>
  /// Represents the faker.
  /// </summary>
  protected static readonly Faker Faker = new();

  /// <summary>
  /// Represents the sender.
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Reviewed")]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Reviewed")]
  protected readonly ISender Sender;

  /// <summary>
  /// Represents the HTTP client.
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Reviewed")]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Reviewed")]
  protected readonly HttpClient HttpClient;

  /// <summary>
  /// Represents the database context.
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Reviewed")]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "Reviewed")]
  protected readonly AdministrationDbContext DbContext;

  private readonly IServiceScope _scope;
  private readonly KeyCloakOptions _options;
  private bool _disposedValue;

  /// <summary>
  /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
  /// </summary>
  /// <param name="factory">An instance of the <see cref="IntegrationTestWebAppFactory"/>.</param>
  protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
  {
    ArgumentNullException.ThrowIfNull(factory);
    _scope = factory.Services.CreateScope();
    Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
    HttpClient = factory.CreateClient();
    _options = _scope.ServiceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;
    DbContext = _scope.ServiceProvider.GetRequiredService<AdministrationDbContext>();
  }

  /// <inheritdoc/>
  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  /// <summary>
  /// Gets an access token from the Keycloak server.
  /// </summary>
  /// <param name="email">The username.</param>
  /// <param name="password">The password.</param>
  /// <returns>An asynchronous task with the access token.</returns>
  protected async Task<string> GetAccessTokenAsync(string email, string password)
  {
    using var client = new HttpClient();

    var authRequestParameters = new KeyValuePair<string, string>[]
    {
      new("client_id", _options.PublicClientId),
      new("scope", "openid"),
      new("grant_type", "password"),
      new("username", email),
      new("password", password),
    };

    using var authRequestContent = new FormUrlEncodedContent(authRequestParameters);

    using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_options.TokenUrl))
    {
      Content = authRequestContent,
    };

    using var authResponse = await client.SendAsync(authRequest);

    authResponse.EnsureSuccessStatusCode();

    var authToken = await authResponse.Content.ReadFromJsonAsync<AuthToken>();

    return authToken!.AccessToken;
  }

  /// <summary>
  /// Disposes the resources.
  /// </summary>
  /// <param name="disposing">Whether or not the resources should be disposed of.</param>
  protected virtual void Dispose(bool disposing)
  {
    if (!_disposedValue)
    {
      if (disposing)
      {
        _scope.Dispose();
        HttpClient.Dispose();
        DbContext.Dispose();
      }

      _disposedValue = true;
    }
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
