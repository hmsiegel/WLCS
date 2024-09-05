// <copyright file="UserConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasConversion(
      id => id.Value,
      value => UserId.Create(value));

    builder.Property(x => x.FirstName)
      .HasMaxLength(FirstName.MaxLength)
      .HasConversion(
      firstName => firstName.Value,
      value => FirstName.Create(value).Value);

    builder.Property(x => x.LastName)
      .HasMaxLength(LastName.MaxLength)
      .HasConversion(
      lastName => lastName.Value,
      value => LastName.Create(value).Value);

    builder.Property(x => x.Email)
      .HasMaxLength(256)
      .HasConversion(
      email => email.Value,
      value => Email.Create(value).Value);

    builder.HasIndex(x => x.Email)
      .IsUnique();

    builder.HasIndex(x => x.IdentityId)
      .IsUnique();
  }
}
