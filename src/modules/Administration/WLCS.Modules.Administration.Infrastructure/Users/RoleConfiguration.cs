// <copyright file="RoleConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

/// <summary>
/// Configures the entity type for the <see cref="Role"/> class.
/// </summary>
internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("roles");

    builder.HasKey(r => r.Name);

    builder.Property(r => r.Name)
      .HasMaxLength(50);

    builder.HasMany<User>()
      .WithMany(r => r.Roles)
      .UsingEntity(joinBuilder =>
      {
        joinBuilder.ToTable("user_roles");
        joinBuilder.Property("RolesName").HasColumnName("role_name");
      });

    builder.HasData(
      Role.User,
      Role.Administrator,
      Role.CompetitionDirector);
  }
}
