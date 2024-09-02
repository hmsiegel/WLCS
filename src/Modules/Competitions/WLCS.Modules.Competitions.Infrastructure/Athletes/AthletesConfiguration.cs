// <copyright file="AthletesConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Infrastructure.Athletes;

internal sealed class AthletesConfiguration : IEntityTypeConfiguration<Athlete>
{
  public void Configure(EntityTypeBuilder<Athlete> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedNever();

    builder.Property(a => a.Gender)
      .HasConversion(
      gender => gender.Value,
      value => Gender.FromValue(value));
  }
}
