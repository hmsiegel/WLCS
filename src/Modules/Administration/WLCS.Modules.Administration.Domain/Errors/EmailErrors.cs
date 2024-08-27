// <copyright file="EmailErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Domain.Errors;

public static class EmailErrors
{
  public static readonly Error Empty = new(
    "Email.Empty",
    "Email cannot be empty.",
    ErrorType.Problem);

  public static readonly Error TooLong = new(
    "Email.TooLong",
    "Email is too long.",
    ErrorType.Problem);

  public static readonly Error InvalidFormat = new(
    "Email.InvalidFormat",
    "Email is in an invalid format.",
    ErrorType.Problem);
}
