// <copyright file="UserRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

internal sealed class UserRepository(AdministrationDbContext context) : IUserRepository
{
  private readonly AdministrationDbContext _context = context;

  public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var users = await _context.Users
      .Include(x => x.Roles)
      .ToListAsync(cancellationToken);
    var user = users.Find(x => x.Id.Value == id);
    return user;
  }

  public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default)
  {
    return !await _context.Users.AnyAsync(x => x.Email == email, cancellationToken);
  }

  public void Add(User user)
  {
    foreach (var role in user.Roles)
    {
      _context.Attach(role);
    }

    _context.Users.Add(user);
  }

  public void Update(User user)
  {
    _context.Users.Update(user);
  }

  public async Task<Guid> GetIdentityIdAsync(Guid userId, CancellationToken cancellationToken = default)
  {
    var users = await _context.Users.ToListAsync(cancellationToken);
    var user = users.Find(x => x.Id.Value == userId);
    var identityId = user!.IdentityId;
    return Guid.Parse(identityId);
  }
}
