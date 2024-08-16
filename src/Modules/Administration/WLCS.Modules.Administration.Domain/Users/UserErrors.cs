// <copyright file="UserErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public static class UserErrors
{
  public static Error NotFoud(Guid userId) => Error.NotFound(
    "Users.NotFound",
    $"User with id {userId} not found");

  public static Error NotFoud(string identitiyId) => Error.NotFound(
    "Users.NotFound",
    $"User with id {identitiyId} not found");
}
