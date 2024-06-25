// <copyright file="UserConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

/// <summary>
/// Configures the user entity.
/// </summary>
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(user => user.Id);

    builder.Property(user => user.Email)
      .IsRequired()
      .HasMaxLength(256);

    builder.Property(u => u.FirstName)
      .IsRequired()
      .HasMaxLength(256);

    builder.Property(u => u.LastName)
      .IsRequired()
      .HasMaxLength(256);

    builder.HasIndex(builder => builder.Email)
      .IsUnique();

    builder.HasIndex(u => u.IdentityId).IsUnique();
  }
}
