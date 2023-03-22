namespace Persistence.Repositories;
public sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Set<User>().Add(user);
    }

    public async Task Delete(User user)
    {
        var dbContact = await GetByIdAsync(user.Id!.Value);

        if (dbContact is not null)
        {
            dbContact.DeleteUser();
            dbContact.DeletedAtUtc = DateTime.UtcNow;
        }
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default) =>
        await _context
            .Set<User>()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        List<User> users = await _context
            .Set<User>()
            .ToListAsync(cancellationToken);

        var user = users
            .Where(x => x.Id!.Value == id)
            .FirstOrDefault();

        return user;
    }


    public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default) =>
        !await _context.Set<User>().AnyAsync(x => x.Email == email, cancellationToken);

    public void Update(User user)
    {
        _context.Set<User>().Update(user);
    }
}
