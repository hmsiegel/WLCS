// <copyright file="MeetConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Meets;

internal sealed class MeetConfiguration : IEntityTypeConfiguration<Meet>
{
  public void Configure(EntityTypeBuilder<Meet> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedNever();

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(x => x.Location)
      .HasMaxLength(500);

    builder.Property(x => x.Venue)
      .HasMaxLength(500);

    builder.Property(x => x.StartDate)
      .IsRequired();

    builder.Property(x => x.EndDate)
      .IsRequired();

    builder.HasMany(x => x.Competitions);
  }
}
