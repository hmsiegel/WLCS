namespace Modules.Users.Domain.Roles;

/// <summary>
/// Represents the role enumeration.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Role"/> class.
/// </remarks>
/// <param name="name">The name.</param>
/// <param name="value">The value.</param>
public sealed class Role(string name, int value) : SmartEnum<Role>(name, value)
{
    /// <summary>
    /// Registered.
    /// </summary>
    public static readonly Role Registered = new (nameof(Registered), 0);

    /// <summary>
    /// Administrator.
    /// </summary>
    public static readonly Role Administrator = new (nameof(Administrator), 100);

    /// <summary>
    /// Gets the users.
    /// </summary>
    public IReadOnlyCollection<User> Users { get; } = [];
}
