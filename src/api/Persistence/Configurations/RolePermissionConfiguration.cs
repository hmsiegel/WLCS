namespace Persistence.Configurations;
internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        builder.HasData(
            Create(Role.Admin, UserPermissions.ReadUser),
            Create(Role.Admin, UserPermissions.UpdateUser),
            Create(Role.Admin, UserPermissions.DeleteUser),
            Create(Role.Admin, UserPermissions.CreateUser),
            Create(Role.Scorekeeper, UserPermissions.ReadUser));
    }

    private static RolePermission Create(
        Role role,
        UserPermissions userPermission)
    {
        return new RolePermission
        {
            RoleId = role.Id,
            PermissionId = (int)userPermission
        };
    }
}
