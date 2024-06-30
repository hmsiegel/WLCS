// <copyright file="IntegrationTestWebAppFactory.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Abstractions;

/// <summary>
/// Represents the integration test web application factory.
/// </summary>
public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
  private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
    .WithImage("postgres:latest")
    .WithDatabase("wlcs")
    .WithUsername("wlcs")
    .WithPassword("wlcs")
    .Build();

  private readonly RedisContainer _redisContainer = new RedisBuilder()
    .WithImage("redis:latest")
    .Build();

  private readonly KeycloakContainer _keycloakContainer = new KeycloakBuilder()
    .WithImage("quay.io/keycloak/keycloak:latest")
    .WithResourceMapping(
      new FileInfo("wlcs-realm-export.json"),
      new FileInfo("/opt/keycloak/data/import/realm.json"))
    .WithCommand("--import-realm")
    .Build();

  /// <summary>
  /// Initializes the integration test web application factory.
  /// </summary>
  /// <returns>An asynchronous task.</returns>
  public async Task InitializeAsync()
  {
    await _dbContainer.StartAsync();
    await _redisContainer.StartAsync();
    await _keycloakContainer.StartAsync();
  }

  /// <summary>
  /// Disposes the integration test web application factory.
  /// </summary>
  /// <returns>An asynchronous task.</returns>
  public new async Task DisposeAsync()
  {
    await _dbContainer.StopAsync();
    await _redisContainer.StopAsync();
    await _keycloakContainer.StopAsync();
    await _dbContainer.DisposeAsync();
    await _redisContainer.DisposeAsync();
    await _keycloakContainer.DisposeAsync();
  }

  /// <inheritdoc/>
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    Environment.SetEnvironmentVariable("ConnectionStrings:Database", _dbContainer.GetConnectionString());
    Environment.SetEnvironmentVariable("ConnectionStrings:Cache", _redisContainer.GetConnectionString());

    var keyCloakAddress = _keycloakContainer.GetBaseAddress();
    var keyCloakRealmUrl = $"{keyCloakAddress}realms/wlcs";

    Environment.SetEnvironmentVariable(
      "Authentication:MetadataAddress",
      $"{keyCloakRealmUrl}/.well-known/openid-configuration");

    Environment.SetEnvironmentVariable(
      "Authentication:TokenValidationParameters:ValidIssuer",
      keyCloakRealmUrl);

    builder.ConfigureTestServices(services =>
    {
      services.Configure<KeyCloakOptions>(o =>
      {
        o.AdminUrl = $"{keyCloakAddress}admin/realms/wlcs/";
        o.TokenUrl = $"{keyCloakRealmUrl}/protocol/openid-connect/token";
      });
    });
  }
}
