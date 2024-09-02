// <copyright file="CompetitionConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
using Name = WLCS.Modules.Competitions.Domain.Competitions.ValueObjects.Name;

namespace WLCS.Modules.Competitions.Infrastructure.Competitions;

internal sealed class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
{
  public void Configure(EntityTypeBuilder<Competition> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedNever()
      .HasConversion(
      id => id.Value,
      value => new CompetitionId(value));

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(200)
      .HasConversion(
      name => name.Value,
      value => new Name(value));

    builder.HasMany(x => x.Athletes)
      .WithMany();
  }
}
