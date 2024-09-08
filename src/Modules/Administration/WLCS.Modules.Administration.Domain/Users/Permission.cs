// <copyright file="Permission.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Users;

public sealed class Permission(string code)
{
  public static readonly Permission GetUser = new("users:read");

  public static readonly Permission ModifyUser = new("users:update");

  public static readonly Permission CreateMeet = new("meets:create");

  public static readonly Permission SearchMeets = new("meets:search");

  public static readonly Permission GetMeets = new("meets:read");

  public static readonly Permission ModifyMeet = new("meets:update");

  public static readonly Permission CreateCompetition = new("competitions:create");

  public static readonly Permission ModifyCompetition = new("competitions:update");

  public static readonly Permission GetCompetition = new("competitions:read");

  public static readonly Permission CreateAthlete = new("athletes:create");

  public static readonly Permission SearchAthletes = new("athletes:search");

  public static readonly Permission GetAthletes = new("athletes:read");

  public static readonly Permission ModifyAthlete = new("athletes:update");

  public string Code { get; } = code;
}
