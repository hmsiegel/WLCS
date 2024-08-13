// <copyright file="CompetitionsDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Database;

public class CompetitionsDbContext(DbContextOptions<CompetitionsDbContext> options)
  : DbContext(options), IUnitOfWork
{
  internal DbSet<Meet> Meets { get; set; } = null!;

  internal DbSet<Competition> Competitions { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("competitions");
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.ConfigureSmartEnum();
  }
}
