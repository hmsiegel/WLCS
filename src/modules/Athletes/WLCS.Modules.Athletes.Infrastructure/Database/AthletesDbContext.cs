// <copyright file="AthletesDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Database;

/// <summary>
/// Initializes a new instance of the <see cref="AthletesDbContext"/> class.
/// </summary>
/// <param name="options">Represents the options to use.</param>
public sealed class AthletesDbContext(DbContextOptions<AthletesDbContext> options)
  : DbContext(options), IUnitOfWork
{
  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(Schemas.Athletes);
  }
}
