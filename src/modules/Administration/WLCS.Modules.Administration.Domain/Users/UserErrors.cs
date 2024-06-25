// <copyright file="UserErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

/// <summary>
/// Represents the user errors.
/// </summary>
public static class UserErrors
{
  /// <summary>
  /// Represents the user not found error.
  /// </summary>
  /// <param name="userId">The id of the user.</param>
  /// <returns>The user not found error.</returns>
  public static Error NotFound(Guid userId) =>
    Error.NotFound(
      "Users.NotFound",
      $"User with id {userId} was not found.");

  /// <summary>
  /// Represents the user not found error.
  /// </summary>
  /// <param name="identityId">The identity Id of the user..</param>
  /// <returns>The user not found error.</returns>
  public static Error NotFound(string identityId) =>
    Error.NotFound(
      "Users.NotFound",
      $"User with id {identityId} was not found.");
}
