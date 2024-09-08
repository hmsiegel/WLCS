// <copyright file="Role.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public sealed class Role
{
  public static readonly Role Administrator = new("Administrator");
  public static readonly Role CompDirector = new("CompDirector");
  public static readonly Role User = new("User");

  private Role(string name)
  {
    Name = name;
  }

  private Role()
  {
  }

  public string Name { get; private set; } = string.Empty;
}
