namespace Infrastructure.Authentication.Permissions;
public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(UserPermissions permission)
        :base(policy: permission.ToString())
    {
        
    }
}
