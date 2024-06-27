// <copyright file="PermissionConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

/// <summary>
/// Configures the entity type for the <see cref="Permission"/> class.
/// </summary>
internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
    builder.ToTable("permissions");

    builder.HasKey(p => p.Code);

    builder.Property(p => p.Code)
      .HasMaxLength(100);

    builder.HasData(
      Permission.GetMeets,
      Permission.CreateMeet,
      Permission.GetUser);

    builder
      .HasMany<Role>()
      .WithMany()
      .UsingEntity(joinBuilder =>
      {
        joinBuilder.ToTable("role_permissions");

        // User permissions
        joinBuilder.HasData(
          CreateRolePermission(Role.User, Permission.GetUser));

        // Administrator permissions
        joinBuilder.HasData(
          CreateRolePermission(Role.Administrator, Permission.GetMeets),
          CreateRolePermission(Role.Administrator, Permission.CreateMeet),
          CreateRolePermission(Role.Administrator, Permission.GetUser));

        // Competition director permissions
        joinBuilder.HasData(
          CreateRolePermission(Role.CompetitionDirector, Permission.GetMeets),
          CreateRolePermission(Role.CompetitionDirector, Permission.CreateMeet),
          CreateRolePermission(Role.CompetitionDirector, Permission.GetUser));
      });
  }

  private static object CreateRolePermission(Role role, Permission permission)
  {
    return new
    {
      RoleName = role.Name,
      PermissionCode = permission.Code,
    };
  }
}
