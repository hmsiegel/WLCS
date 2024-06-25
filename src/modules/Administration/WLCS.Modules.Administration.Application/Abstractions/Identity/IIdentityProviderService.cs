// <copyright file="IIdentityProviderService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Application.Abstractions.Identity;

/// <summary>
/// Interface for the identity provider service.
/// </summary>
public interface IIdentityProviderService
{
  /// <summary>
  /// Registers a user with the identity provider.
  /// </summary>
  /// <param name="usermodel">A user.</param>
  /// <param name="cancellationToken">A cancellation token.</param>
  /// <returns>A string indicating a success or failure.</returns>
  Task<Result<string>> RegisterUserAsync(UserModel usermodel, CancellationToken cancellationToken = default);
}
