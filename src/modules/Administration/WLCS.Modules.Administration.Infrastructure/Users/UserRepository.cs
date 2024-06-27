// <copyright file="UserRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Users;

/// <inheritdoc/>
/// <summary>
/// Initializes a new instance of the <see cref="UserRepository"/> class.
/// </summary>
/// <param name="context">The database context.</param>
internal sealed class UserRepository(AdministrationDbContext context) : IUserRepository
{
  private readonly AdministrationDbContext _context = context;

  /// <inheritdoc/>
  public void Add(User user)
  {
    foreach (var role in user.Roles)
    {
      _context.Attach(role);
    }

    _context.Users.Add(user);
  }

  /// <inheritdoc/>
  public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
      .ConfigureAwait(false);
  }
}
