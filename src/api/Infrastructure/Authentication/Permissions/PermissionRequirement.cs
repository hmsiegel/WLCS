namespace Infrastructure.Authentication.Permissions;
public sealed class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}
