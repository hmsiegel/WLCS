// <copyright file="AgeDivision.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class AgeDivision(string name, int value) : SmartEnum<AgeDivision>(name, value)
{
  public static readonly AgeDivision Open = new(nameof(Open), 0);
  public static readonly AgeDivision Youth = new(nameof(Youth), 1);
  public static readonly AgeDivision Junior = new(nameof(Junior), 2);
  public static readonly AgeDivision Senior = new(nameof(Senior), 3);
  public static readonly AgeDivision Master = new(nameof(Master), 4);
  public static readonly AgeDivision Under11 = new(nameof(Under11), 5);
  public static readonly AgeDivision All = new(nameof(All), 6);
}
