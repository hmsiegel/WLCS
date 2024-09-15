// <copyright file="BaseIntegrationTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
public abstract class BaseIntegrationTest : IDisposable
{
  protected static readonly Faker Faker = new();

  private readonly ISender _sender;

  private readonly IServiceScope _scope;

  protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
  {
    ArgumentNullException.ThrowIfNull(factory);
    _scope = factory.Services.CreateScope();
    _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
  }

  protected ISender Sender => _sender;

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (disposing)
    {
      _scope.Dispose();
    }
  }
}
