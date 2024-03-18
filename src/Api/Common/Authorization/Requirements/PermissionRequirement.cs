namespace Authorization.Requirements;

/// <summary>
/// Represents the <see cref="PermissionRequirement"/> class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PermissionRequirement"/> class.
/// </remarks>
/// <param name="permission">The permission.</param>
internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    /// <summary>
    /// Gets the permission.
    /// </summary>
    internal string Permission { get; } = permission;
}
