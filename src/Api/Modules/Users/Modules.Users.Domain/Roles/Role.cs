namespace Modules.Users.Domain.Roles;

/// <summary>
/// Represents the role enumeration.
/// </summary>
public sealed class Role : Enumeration<Role>
{
    /// <summary>
    /// Registered.
    /// </summary>
    public static readonly Role Registered = new (1, "Registered");

    /// <summary>
    /// Administrator.
    /// </summary>
    public static readonly Role Administrator = new (100, "Administrator");

    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    private Role(int id, string name)
        : base(id, name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    private Role()
    {
    }

    /// <summary>
    /// Gets the users.
    /// </summary>
    public IReadOnlyCollection<User> Users { get; } = [];
}
