// <copyright file="Scope.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class Scope : SmartEnum<Scope>
{
  public static readonly Scope USAW = new(nameof(USAW), 0);
  public static readonly Scope IWF = new(nameof(IWF), 1);

  public Scope(string name, int value)
    : base(name, value)
  {
  }
}
