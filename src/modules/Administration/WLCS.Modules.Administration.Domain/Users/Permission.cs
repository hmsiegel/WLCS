// <copyright file="Permission.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

/// <summary>
/// Represents a permission.
/// </summary>
public sealed class Permission
{
  /// <summary>
  /// Represents the get user permission.
  /// </summary>
  public static readonly Permission GetUser = new("users:read");

  /// <summary>
  /// Represents the modify user permission.
  /// </summary>
  public static readonly Permission ModifyUser = new("users:update");

  /// <summary>
  /// Represents the get meet user permission.
  /// </summary>
  public static readonly Permission GetMeets = new("meets:read");

  /// <summary>
  /// Represents the create meet user permission.
  /// </summary>
  public static readonly Permission CreateMeet = new("meets:create");

  /// <summary>
  /// Initializes a new instance of the <see cref="Permission"/> class.
  /// </summary>
  /// <param name="code">The permission code.</param>
  public Permission(string code)
  {
    Code = code;
  }

  /// <summary>
  /// Gets the name of the permission.
  /// </summary>
  public string Code { get; } = string.Empty;
}
