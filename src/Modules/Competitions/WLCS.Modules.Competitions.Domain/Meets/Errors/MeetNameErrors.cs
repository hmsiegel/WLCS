// <copyright file="MeetNameErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Meets.Errors;

public static class MeetNameErrors
{
  public static readonly Error Empty = Error.Problem(
    code: "MeetName.Empty",
    description: "The meet name cannot be empty.");

  public static readonly Error Invalid = Error.Problem(
    code: "MeetName.Invalid",
    description: "The meet name is invalid.");

  public static readonly Error TooLong = Error.Problem(
    code: "MeetName.TooLong",
    description: "The meet name is too long.");
}
