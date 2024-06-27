// <copyright file="CommunicationDbContext.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Database;

/// <summary>
/// Initializes a new instance of the <see cref="CommunicationDbContext"/> class.
/// </summary>
/// <param name="options">Represents the options to use.</param>
public sealed class CommunicationDbContext(DbContextOptions<CommunicationDbContext> options)
  : DbContext(options), IUnitOfWork
{
  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema(Schemas.Communication);
  }
}
