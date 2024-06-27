// <copyright file="SchedulingDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Scheduling.Infrastructure.Database;

/// <summary>
/// Initializes a new instance of the <see cref="SchedulingDbContext"/> class.
/// </summary>
/// <param name="options">Represents the options to use.</param>
public sealed class SchedulingDbContext(DbContextOptions<SchedulingDbContext> options)
  : DbContext(options), IUnitOfWork
{
  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(Schemas.Scheduling);
  }
}
