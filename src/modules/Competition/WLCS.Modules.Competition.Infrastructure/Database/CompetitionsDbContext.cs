// <copyright file="CompetitionsDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Infrastructure.Database;

/// <summary>
/// Initializes a new instance of the <see cref="CompetitionsDbContext"/> class.
/// </summary>
/// <param name="options">Represents the options to use.</param>
public sealed class CompetitionsDbContext(DbContextOptions<CompetitionsDbContext> options)
  : DbContext(options), IUnitOfWork
{
  /// <summary>
  /// Gets or sets the meets.
  /// </summary>
  internal DbSet<Meet> Meets { get; set; }

  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(Schemas.Competitions);
  }
}
