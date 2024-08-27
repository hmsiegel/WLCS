// <copyright file="FirstNameErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Domain.Athletes.Errors;

public static class FirstNameErrors
{
  public static readonly Error Empty = new(
          "FirstName.Empty",
          "First name cannot be empty",
          ErrorType.Problem);

  public static readonly Error Length = new(
          "FirstName.Length",
          "The first name is too long.",
          ErrorType.Validation);
}
