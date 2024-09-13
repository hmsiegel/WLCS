// <copyright file="BaseIntegrationTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
public class BaseIntegrationTest : IDisposable
{
  protected static readonly Faker Faker = new();

  private readonly ISender _sender;

  private readonly HttpClient _httpClient;

  private readonly AdministrationDbContext _dbContext;

  private readonly IServiceScope _scope;

  private readonly KeyCloakOptions _keyCloakOptions;

  protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
  {
    ArgumentNullException.ThrowIfNull(factory);
    _scope = factory.Services.CreateScope();
    _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
    _httpClient = factory.CreateClient();
    _dbContext = _scope.ServiceProvider.GetRequiredService<AdministrationDbContext>();
    _keyCloakOptions = _scope.ServiceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;
  }

  protected ISender Sender => _sender;

  protected HttpClient HttpClient => _httpClient;

  protected AdministrationDbContext DbContext => _dbContext;

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected async Task<string> GetAccessTokenAsync(string email, string password)
  {
    using var client = new HttpClient();

    var authRequestParameters = new KeyValuePair<string, string>[]
    {
      new("client_id", _keyCloakOptions.PublicClientId),
      new("scope", "openid"),
      new("grant_type", "password"),
      new("username", email),
      new("password", password),
    };

    using var authRequestContent = new FormUrlEncodedContent(authRequestParameters);

    using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_keyCloakOptions.TokenUrl));
    authRequest.Content = authRequestContent;

    using var authResponse = await client.SendAsync(authRequest);
    authResponse.EnsureSuccessStatusCode();

    var authToken = await authResponse.Content.ReadFromJsonAsync<AuthToken>();

    return authToken!.AccessToken;
  }

  protected virtual void Dispose(bool disposing)
  {
    if (disposing)
    {
      _dbContext.Dispose();
      _scope.Dispose();
      _httpClient.Dispose();
    }
  }

  internal sealed class AuthToken
  {
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; } = default!;
  }
}
