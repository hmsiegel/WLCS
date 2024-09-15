// <copyright file="AdministrationDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Database;

public class AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
  : DbContext(options), IUnitOfWork
{
  internal DbSet<User> Users { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ArgumentNullException.ThrowIfNull(modelBuilder);
    modelBuilder.HasDefaultSchema(Schemas.Administration);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdministrationModule).Assembly);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutboxMessage).Assembly);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.ConfigureSmartEnum();
  }
}
