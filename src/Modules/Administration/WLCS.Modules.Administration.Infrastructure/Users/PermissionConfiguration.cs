// <copyright file="PermissionConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
  public void Configure(EntityTypeBuilder<Permission> builder)
  {
    builder.ToTable("permissions");

    builder.HasKey(p => p.Code);

    builder.Property(p => p.Code)
      .HasColumnName("code")
      .HasMaxLength(50)
      .IsRequired();

    builder.HasData(
      Permission.GetMeets,
      Permission.CreateMeet,
      Permission.ModifyMeet,
      Permission.SearchMeets,
      Permission.CreateCompetition,
      Permission.ModifyCompetition,
      Permission.GetCompetition,
      Permission.CreateAthlete,
      Permission.ModifyAthlete,
      Permission.GetAthletes,
      Permission.SearchAthletes,
      Permission.GetUser,
      Permission.ModifyUser);

    builder
      .HasMany<Role>()
      .WithMany()
      .UsingEntity(j => j.ToTable("role_permissions")
        .HasData(
          CreateRolePermission(Role.Administrator, Permission.GetMeets),
          CreateRolePermission(Role.Administrator, Permission.CreateMeet),
          CreateRolePermission(Role.Administrator, Permission.ModifyMeet),
          CreateRolePermission(Role.Administrator, Permission.SearchMeets),
          CreateRolePermission(Role.Administrator, Permission.CreateAthlete),
          CreateRolePermission(Role.Administrator, Permission.ModifyAthlete),
          CreateRolePermission(Role.Administrator, Permission.SearchAthletes),
          CreateRolePermission(Role.Administrator, Permission.GetUser),
          CreateRolePermission(Role.Administrator, Permission.ModifyUser),
          CreateRolePermission(Role.Administrator, Permission.GetAthletes),
          CreateRolePermission(Role.Administrator, Permission.CreateCompetition),
          CreateRolePermission(Role.Administrator, Permission.ModifyCompetition),
          CreateRolePermission(Role.CompDirector, Permission.CreateMeet),
          CreateRolePermission(Role.CompDirector, Permission.ModifyMeet),
          CreateRolePermission(Role.CompDirector, Permission.SearchMeets),
          CreateRolePermission(Role.CompDirector, Permission.CreateCompetition),
          CreateRolePermission(Role.CompDirector, Permission.ModifyCompetition),
          CreateRolePermission(Role.CompDirector, Permission.SearchAthletes),
          CreateRolePermission(Role.CompDirector, Permission.CreateAthlete),
          CreateRolePermission(Role.CompDirector, Permission.ModifyAthlete),
          CreateRolePermission(Role.User, Permission.GetMeets),
          CreateRolePermission(Role.User, Permission.CreateMeet),
          CreateRolePermission(Role.User, Permission.ModifyMeet),
          CreateRolePermission(Role.User, Permission.CreateAthlete),
          CreateRolePermission(Role.User, Permission.ModifyAthlete),
          CreateRolePermission(Role.User, Permission.GetUser),
          CreateRolePermission(Role.User, Permission.ModifyUser),
          CreateRolePermission(Role.User, Permission.GetAthletes),
          CreateRolePermission(Role.User, Permission.CreateCompetition),
          CreateRolePermission(Role.User, Permission.ModifyCompetition),
          CreateRolePermission(Role.User, Permission.SearchMeets),
          CreateRolePermission(Role.User, Permission.SearchAthletes)));
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
