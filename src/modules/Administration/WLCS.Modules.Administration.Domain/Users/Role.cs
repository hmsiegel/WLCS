// <copyright file="Role.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

/// <summary>
/// Represents a role.
/// </summary>
public sealed class Role
{
  /// <summary>
  /// Represents the administrator role.
  /// </summary>
  public static readonly Role Administrator = new("Administrator");

  /// <summary>
  /// Represents the competition director role.
  /// </summary>
  public static readonly Role CompetitionDirector = new("CompetitionDirector");

  /// <summary>
  /// Represents the user role.
  /// </summary>
  public static readonly Role User = new("User");

  private Role(string name)
  {
    Name = name;
  }

  private Role()
  {
  }

  /// <summary>
  /// Gets the name of the role.
  /// </summary>
  public string Name { get; private set; } = string.Empty;
}
