// <copyright file="AthleteConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Infrastructure.Athletes;

internal sealed class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
{
  public void Configure(EntityTypeBuilder<Athlete> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedNever()
      .HasConversion(
      id => id.Value,
      value => AthleteId.Create(value));

    builder.Property(a => a.FirstName)
      .HasMaxLength(100)
      .HasConversion(
      firstName => firstName.Value,
      value => new FirstName(value));

    builder.Property(a => a.LastName)
      .HasMaxLength(100)
      .HasConversion(
      lastName => lastName.Value,
      value => new LastName(value));

    builder.Property(a => a.Email)
      .HasMaxLength(255)
      .HasConversion(
      email => email.Value,
      value => new Email(value));

    builder.Property(a => a.Coach)
      .HasMaxLength(255)
      .HasConversion(
      coach => coach!.Value,
      value => new Coach(value));

    builder.Property(a => a.PhoneNumber)
      .HasMaxLength(20)
      .HasConversion(
      phoneNumber => phoneNumber!.Value,
      value => new PhoneNumber(value));

    builder.Property(a => a.DateOfBirth)
      .IsRequired();

    builder.Property(a => a.Gender)
      .HasConversion(
      gender => gender.Value,
      value => Gender.FromValue(value));

    builder.OwnsOne(a => a.Membership, membershipBuilder =>
    {
      membershipBuilder.Property(mb => mb.ExpirationDate)
      .HasColumnName("member_expiration_date");

      membershipBuilder.Property(mb => mb.MembershipId)
        .HasMaxLength(8)
        .HasColumnName("memberId")
        .IsRequired();

      membershipBuilder.HasIndex(x => x.MembershipId).IsUnique();
    });

    builder.OwnsOne(a => a.Address, addressBuilder =>
    {
      addressBuilder.Property(ad => ad.Street1)
        .HasColumnName("street1")
        .HasMaxLength(100);

      addressBuilder.Property(ad => ad.Street2)
        .HasColumnName("street2")
        .HasMaxLength(100);

      addressBuilder.Property(ad => ad.Street3)
        .HasColumnName("street3")
        .HasMaxLength(100);

      addressBuilder.Property(ad => ad.City)
        .HasColumnName("city")
        .HasMaxLength(100);

      addressBuilder.Property(ad => ad.State)
        .HasColumnName("state")
        .HasMaxLength(2);

      addressBuilder.Property(ad => ad.ZipCode)
        .HasColumnName("zip_code")
        .HasMaxLength(10);

      addressBuilder.Property(ad => ad.Country)
        .HasColumnName("country")
        .HasMaxLength(100);
    });

    builder.OwnsOne(a => a.Club, clubBuilder =>
    {
      clubBuilder.Property(c => c.ClubCode)
        .HasColumnName("club_code")
        .HasMaxLength(8);

      clubBuilder.Property(c => c.Name)
        .HasColumnName("club_name")
        .HasMaxLength(100);
    });
  }
}
