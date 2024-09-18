// <copyright file="CommunicationDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Database;

public class CommunicationDbContext(DbContextOptions<CommunicationDbContext> options)
  : DbContext(options), IUnitOfWork
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ArgumentNullException.ThrowIfNull(modelBuilder);
    modelBuilder.HasDefaultSchema(Schemas.Communication);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutboxMessage).Assembly);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommunicationModule).Assembly);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.ConfigureSmartEnum();
  }
}
