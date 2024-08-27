// <copyright file="Gender.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public sealed class Gender(string name, int value) : SmartEnum<Gender>(name, value)
{
  public static readonly Gender Male = new(nameof(Male), 0);
  public static readonly Gender Female = new(nameof(Female), 1);
}
