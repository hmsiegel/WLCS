// <copyright file="CompetitionsDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Database;

public class CompetitionsDbContext(DbContextOptions<CompetitionsDbContext> options)
  : DbContext(options), IUnitOfWork
{
  internal DbSet<Meet> Meets { get; set; } = null!;

  internal DbSet<Competition> Competitions { get; set; } = null!;

  internal DbSet<Athlete> Athletes { get; set; } = null!;

  internal DbSet<Platform> Platforms { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ArgumentNullException.ThrowIfNull(modelBuilder);
    modelBuilder.HasDefaultSchema(Schemas.Competitions);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutboxMessage).Assembly);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompetitionModule).Assembly);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.ConfigureSmartEnum();
  }
}
