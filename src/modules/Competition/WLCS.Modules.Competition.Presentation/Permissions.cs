// <copyright file="Permissions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.Presentation;

/// <summary>
/// Permissions for the Competition module.
/// </summary>
internal static class Permissions
{
  /// <summary>
  /// Permission to get a single meet.
  /// </summary>
  internal const string GetMeet = "meets:read";

  /// <summary>
  /// Permission to get all the meets.
  /// </summary>
  internal const string GetMeets = "meets:read";

  /// <summary>
  ///  Permission to create a meet.
  /// </summary>
  internal const string CreateMeet = "meets:create";
}
