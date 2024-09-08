// <copyright file="RoleConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("roles");

    builder.HasKey(r => r.Name);

    builder.Property(r => r.Name)
      .HasColumnName("name")
      .HasMaxLength(50)
      .IsRequired();

    builder
      .HasMany<User>()
      .WithMany(u => u.Roles)
      .UsingEntity(joinBuilder =>
      {
        joinBuilder.ToTable("user_roles");

        joinBuilder.Property("RolesName").HasColumnName("roles_name");
      });

    builder.HasData(
      Role.Administrator,
      Role.User,
      Role.CompDirector);
  }
}
