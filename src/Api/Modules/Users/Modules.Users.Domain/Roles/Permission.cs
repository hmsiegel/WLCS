namespace Modules.Users.Domain.Roles;

/// <summary>
/// Represents the permission enumeration.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Permission"/> class.
/// </remarks>
/// <param name="name">The name.</param>
/// <param name="value">The value.</param>
public sealed class Permission(string name, int value) : SmartEnum<Permission>(name, value)
{
    /// <summary>
    /// Can read user information.
    /// </summary>
    public static readonly Permission ReadUser = new (nameof(ReadUser), 0);

    /// <summary>
    /// Can modify user information.
    /// </summary>
    public static readonly Permission ModifyUser = new (nameof(ModifyUser), 1);
}
