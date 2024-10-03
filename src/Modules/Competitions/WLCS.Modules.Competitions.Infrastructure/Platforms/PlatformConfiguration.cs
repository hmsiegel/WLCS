// <copyright file="PlatformConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Platforms;

internal sealed class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
  public void Configure(EntityTypeBuilder<Platform> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedNever()
      .HasConversion(
      id => id.Value,
      value => new PlatformId(value));

    builder.Property(x => x.PlatformName)
      .IsRequired()
      .HasMaxLength(DatabaseSchemaConstants.DefaultMaxLength)
      .HasConversion(
      name => name.Value,
      value => new PlatformName(value));

    builder.HasMany(x => x.Competitions)
      .WithMany();
  }
}
