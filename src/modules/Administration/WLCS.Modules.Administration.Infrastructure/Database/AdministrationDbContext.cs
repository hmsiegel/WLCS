// <copyright file="AdministrationDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Database;

/// <summary>
/// Initializes a new instance of the <see cref="AdministrationDbContext"/> class.
/// </summary>
/// <param name="options">Represents the options to use.</param>
public sealed class AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
  : DbContext(options), IUnitOfWork
{
  /// <summary>
  /// Gets or sets the users.
  /// </summary>
  public DbSet<User> Users { get; set; }

  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ArgumentNullException.ThrowIfNull(modelBuilder);
    modelBuilder.HasDefaultSchema(Schemas.Administration);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdministrationDbContext).Assembly);
  }
}
