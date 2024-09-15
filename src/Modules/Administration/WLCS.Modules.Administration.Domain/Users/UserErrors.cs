// <copyright file="UserErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public static class UserErrors
{
  public static Error EmailAlreadyInUse => Error.Conflict(
    "Users.EmailAlreadyInUse",
    "Email is already in use");

  public static Error RolesNotFound => Error.NotFound(
    "Users.RolesNotFound",
    "There were no roles found.");

  public static Error UserAlreadyHasRole => Error.Conflict(
    "Users.UserAlreadyHasRole",
    "The specified user is already assigned to the role.");

  public static Error RoleError => Error.Failure(
    "Users.RoleError",
    "An error occurred while adding the role to the user.");

  public static Error NotFound(Guid userId) => Error.NotFound(
    "Users.NotFound",
    $"User with id {userId} not found");

  public static Error NotFound(string identitiyId) => Error.NotFound(
    "Users.NotFound",
    $"User with id {identitiyId} not found");

  public static Error RoleNotFound(string role) => Error.NotFound(
    "Users.RoleNotFound",
    $"Role {role} was not found");
}
