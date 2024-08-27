// <copyright file="LastNameErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.Errors;

public static class LastNameErrors
{
  public static readonly Error Empty = new(
          "LastName.Empty",
          "Last name cannot be empty",
          ErrorType.Problem);

  public static readonly Error Length = new(
          "LastName.Length",
          "The first name is too long.",
          ErrorType.Validation);
}
