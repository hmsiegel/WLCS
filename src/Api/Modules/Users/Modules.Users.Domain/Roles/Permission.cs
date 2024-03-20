namespace Modules.Users.Domain.Roles;

/// <summary>
/// Represents the permission enumeration.
/// </summary>
public sealed class Permission : Enumeration<Permission>
{
    /// <summary>
    /// Read user.
    /// </summary>
    public static readonly Permission ReadUser = new (100, nameof(ReadUser), "Can read user information.");

    /// <summary>
    /// Modify user.
    /// </summary>
    public static readonly Permission ModifyUser = new (101, nameof(ModifyUser), "Can modify user information.");

    /// <summary>
    /// Initializes a new instance of the <see cref="Permission"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="description">The description.</param>
    private Permission(int id, string name, string description)
        : base(id, name) =>
        Description = description;

    /// <summary>
    /// Initializes a new instance of the <see cref="Permission"/> class.
    /// </summary>
    private Permission() => Description = string.Empty;

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; private init; }
}
