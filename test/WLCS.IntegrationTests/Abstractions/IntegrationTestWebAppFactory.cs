// <copyright file="IntegrationTestWebAppFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.IntegrationTests.Abstractions;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
  private readonly MockAuthUser _user = new(
    new Claim("sub", Guid.NewGuid().ToString()),
    new Claim("email", "mock@test.com"));

  private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
    .WithImage("postgres:latest")
    .WithDatabase("wlcs")
    .WithUsername("postgres")
    .WithPassword("postgres")
    .Build();

  private readonly RedisContainer _redisContainer = new RedisBuilder()
    .WithImage("redis:latest")
    .Build();

  private readonly KeycloakContainer _keycloakContainer = new KeycloakBuilder()
    .WithImage("quay.io/keycloak/keycloak:24.0.0")
    .WithResourceMapping(
      new FileInfo("wlcs-realm-export.json"),
      new FileInfo("/opt/keycloak/data/import/realm.json"))
    .WithCommand("--import-realm")
    .Build();

  public async Task InitializeAsync()
  {
    await _dbContainer.StartAsync();
    await _redisContainer.StartAsync();
    await _keycloakContainer.StartAsync();
  }

  public new async Task DisposeAsync()
  {
    await _dbContainer.StopAsync();
    await _redisContainer.StopAsync();
    await _keycloakContainer.StopAsync();

    await _dbContainer.DisposeAsync();
    await _redisContainer.DisposeAsync();
    await _keycloakContainer.DisposeAsync();
  }

  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    Environment.SetEnvironmentVariable("ConnectionStrings:Database", _dbContainer.GetConnectionString());
    Environment.SetEnvironmentVariable("ConnectionStrings:Cache", _redisContainer.GetConnectionString());

    var keycloakAddress = _keycloakContainer.GetBaseAddress();
    var keyCloakRealmUrl = $"{keycloakAddress}realms/wlcs";

    Environment.SetEnvironmentVariable(
      "Authentication:MetadataAddress",
      $"{keyCloakRealmUrl}/.well-known/openid-configuration");
    Environment.SetEnvironmentVariable(
      "Authentication:TokenValidationParameters:ValidIssuer",
      keyCloakRealmUrl);

    builder.ConfigureTestServices(services =>
    {
      services.AddMockAuthentication();
      services.AddScoped(_ => _user);

      services.Configure<KeyCloakOptions>(o =>
      {
        o.AdminUrl = $"{keycloakAddress}admin/realms/wlcs";
        o.TokenUrl = $"{keyCloakRealmUrl}/protocol/openid-connect/token";
      });
    });
  }
}
