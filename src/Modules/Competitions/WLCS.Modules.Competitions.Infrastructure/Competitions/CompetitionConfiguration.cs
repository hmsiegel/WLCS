// <copyright file="CompetitionConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
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
      value => new CompetitionName(value));

    builder.HasMany(x => x.Athletes)
      .WithMany();
  }
}
