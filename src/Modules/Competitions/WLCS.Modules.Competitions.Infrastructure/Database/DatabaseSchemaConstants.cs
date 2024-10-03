// <copyright file="DatabaseSchemaConstants.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Competitions.Infrastructure.Database;

internal static class DatabaseSchemaConstants
{
  internal const string Competitions = "competitions";
  internal const string City = "city";
  internal const string State = "state";

  internal const int DefaultMaxLength = 200;
  internal const int MeetNameMaxLength = 100;
  internal const int VenueMaxLength = 500;
}
