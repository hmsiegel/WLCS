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
      .ValueGeneratedOnAdd();

    builder.Property(x => x.FirstName)
      .HasMaxLength(200);

    builder.Property(x => x.LastName)
      .HasMaxLength(200);

    builder.Property(x => x.Email)
      .HasMaxLength(200);

    builder.HasIndex(x => x.Email)
      .IsUnique();
  }
}
