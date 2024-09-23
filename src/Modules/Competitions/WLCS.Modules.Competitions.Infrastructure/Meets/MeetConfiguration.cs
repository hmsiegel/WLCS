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
      .ValueGeneratedNever()
      .HasConversion(
      id => id.Value,
      value => new MeetId(value));

    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(100)
      .HasConversion(
      name => name.Value,
      value => new MeetName(value));

    builder.OwnsOne(x => x.Location, locationBuilder =>
    {
      locationBuilder
        .Property(x => x.City)
        .HasMaxLength(200)
        .HasColumnName("city");

      locationBuilder
        .Property(x => x.State)
        .HasMaxLength(2)
        .HasColumnName("state");
    });

    builder.Property(x => x.Venue)
      .HasMaxLength(500)
      .HasConversion(
      venue => venue.Value,
      value => new Venue(value));

    builder.Property(x => x.StartDate)
      .IsRequired();

    builder.Property(x => x.EndDate)
      .IsRequired();

    builder
      .HasMany<Competition>()
      .WithOne()
      .HasForeignKey(x => x.MeetId)
      .OnDelete(DeleteBehavior.Cascade);

    builder
      .HasMany<Athlete>()
      .WithOne()
      .HasForeignKey(x => x.MeetId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany<Platform>()
      .WithOne()
      .HasForeignKey(x => x.MeetId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
