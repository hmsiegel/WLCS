// <copyright file="AthletesDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Database;

public class AthletesDbContext(DbContextOptions<AthletesDbContext> options)
  : DbContext(options), IUnitOfWork
{
  internal DbSet<Athlete> Athletes { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ArgumentNullException.ThrowIfNull(modelBuilder);
    modelBuilder.HasDefaultSchema(Schemas.Athletes);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutboxMessage).Assembly);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AthletesModule).Assembly);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.ConfigureSmartEnum();
  }
}
