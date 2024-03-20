namespace Modules.Users.Domain.Roles;

/// <summary>
/// Represents the role-permission join entity.
/// </summary>
public sealed class RolePermission
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RolePermission"/> class.
    /// </summary>
    /// <param name="role">The Role.</param>
    /// <param name="permission">The Permission.</param>
    public RolePermission(Role role, Permission permission)
    {
        if (role is null)
        {
            ArgumentNullException.ThrowIfNull(role);
        }

        if (permission is null)
        {
            ArgumentNullException.ThrowIfNull(permission);
        }

        RoleId = role.Id;
        PermissionId = permission.Id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RolePermission"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private RolePermission()
    {
    }

    /// <summary>
    /// Gets the role identifier.
    /// </summary>
    public int RoleId { get; private set; }

    /// <summary>
    /// Gets the permission identifier.
    /// </summary>
    public int PermissionId { get; private set; }
}
