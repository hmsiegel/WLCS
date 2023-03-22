namespace Domain.Authorization;
public sealed class Role : Enumeration<Role>
{
    public static readonly Role Coach = new(1, "Coach");
    public static readonly Role Admin = new(2, "Admin");
    public static readonly Role Scorekeeper = new(3, "Scorekeeper");

    public Role(int id, string name)
        :base(id, name)
    {
        
    }

    public ICollection<Permission>? Permissions { get; set; }
    public ICollection<User>? Users { get; set; }
}
