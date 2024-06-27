// <copyright file="MeetConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Infrastructure.Meets;

/// <summary>
/// Configures the meet entity.
/// </summary>
internal sealed class MeetConfiguration : IEntityTypeConfiguration<Meet>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<Meet> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedNever();

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(x => x.Venue)
      .HasMaxLength(100);
  }
}
