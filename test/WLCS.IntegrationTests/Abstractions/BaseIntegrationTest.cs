// <copyright file="BaseIntegrationTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.Abstractions;

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

  private readonly IServiceScope _scope;
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
  }

  /// <inheritdoc/>
  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
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
