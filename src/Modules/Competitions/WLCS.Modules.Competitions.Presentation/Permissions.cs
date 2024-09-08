// <copyright file="Permissions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Presentation;

internal static class Permissions
{
  internal const string CreateCompetition = "competitions:create";
  internal const string ModifyCompetition = "competitions:update";
  internal const string GetCompetition = "competitions:read";

  internal const string CreateMeet = "meets:create";
  internal const string SearchMeets = "meets:search";
  internal const string GetMeets = "meets:read";
  internal const string UpdateMeets = "meets:update";
}
