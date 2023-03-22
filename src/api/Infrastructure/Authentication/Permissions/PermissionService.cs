namespace Infrastructure.Authentication.Permissions;
public sealed class PermissionService : IPermissionService
{
    private readonly ApplicationDbContext _dbContext;

    public PermissionService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HashSet<string>> GetPermissionsAsync(Guid userId)
    {
        ICollection<Role>?[] roles = await _dbContext
            .Set<User>()
            .Include(x => x.Roles!)
            .ThenInclude(x => x.Permissions)
            .Where(x => x.Id!.Value == userId)
            .Select(x => x.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(x => x!)
            .SelectMany(x => x.Permissions!)
            .Select(x => x.Name)
            .ToHashSet()!;
    }
}
