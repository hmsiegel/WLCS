namespace Modules.Users.Domain.Users;

/// <summary>
/// Represents the user-role join entity.
/// </summary>
public sealed class UserRole
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRole"/> class.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="roleId">The role id.</param>
    public UserRole(UserId userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRole"/> class.
    /// </summary>
    private UserRole()
    {
    }

    /// <summary>
    /// Gets the user id.
    /// </summary>
    public UserId UserId { get; private set; } = null!;

    /// <summary>
    /// Gets the role id.
    /// </summary>
    public int RoleId { get; private set; }
}
