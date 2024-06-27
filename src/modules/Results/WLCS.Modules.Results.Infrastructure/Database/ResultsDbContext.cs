// <copyright file="ResultsDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Results.Infrastructure.Database;

/// <summary>
/// Initializes a new instance of the <see cref="ResultsDbContext"/> class.
/// </summary>
/// <param name="options">Represents the options to use.</param>
public sealed class ResultsDbContext(DbContextOptions<ResultsDbContext> options)
  : DbContext(options), IUnitOfWork
{
  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(Schemas.Results);
  }
}
