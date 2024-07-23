// <copyright file="Meet.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Api.Meets;

public sealed class Meet
{
  public Guid Id { get; set; }

  public string Name { get; set; } = string.Empty;

  public string Location { get; set; } = string.Empty;

  public string Venue { get; set; } = string.Empty;

  public DateOnly StartDate { get; set; }

  public DateOnly EndDate { get; set; }

  public bool IsActive { get; set; } = true;
}
