// <copyright file="UserRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

internal sealed class UserRepository(AdministrationDbContext context) : IUserRepository
{
  private readonly AdministrationDbContext _context = context;

  public void Add(User user)
  {
    _context.Users.Add(user);
  }

  public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Users.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
  }
}
