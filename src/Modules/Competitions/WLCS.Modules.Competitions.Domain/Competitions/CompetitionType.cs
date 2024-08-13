// <copyright file="CompetitionType.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Competitions;

public sealed class CompetitionType : SmartEnum<CompetitionType>
{
  public static readonly CompetitionType International = new(nameof(International), 0);
  public static readonly CompetitionType National = new(nameof(National), 1);
  public static readonly CompetitionType Local = new(nameof(Local), 2);

  public CompetitionType(string name, int value)
    : base(name, value)
  {
  }
}
