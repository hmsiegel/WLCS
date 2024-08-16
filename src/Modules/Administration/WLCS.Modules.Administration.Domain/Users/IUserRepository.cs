// <copyright file="IUserRepository.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public interface IUserRepository
{
  Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default);

  void Add(User user);
}
