// <copyright file="BaseIntegrationTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
public class BaseIntegrationTest : IDisposable
{
  protected static readonly Faker Faker = new();

  private readonly ISender _sender;

  private readonly HttpClient _httpClient;

  private readonly AdministrationDbContext _dbContext;

  private readonly IServiceScope _scope;

  protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
  {
    ArgumentNullException.ThrowIfNull(factory);
    _scope = factory.Services.CreateScope();
    _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
    _httpClient = factory.CreateClient();
    _dbContext = _scope.ServiceProvider.GetRequiredService<AdministrationDbContext>();
  }

  protected ISender Sender => _sender;

  protected HttpClient HttpClient => _httpClient;

  protected AdministrationDbContext DbContext => _dbContext;

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
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
}
