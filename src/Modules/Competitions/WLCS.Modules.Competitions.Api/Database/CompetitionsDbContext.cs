// <copyright file="CompetitionsDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Api.Database;

public class CompetitionsDbContext(DbContextOptions<CompetitionsDbContext> options)
  : DbContext(options)
{
  internal DbSet<Meet> Meets { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("competitions");
  }
}
