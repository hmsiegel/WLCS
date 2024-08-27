// <copyright file="ValidationError.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public sealed record ValidationError : Error
{
  private readonly ReadOnlyCollection<Error> _errors;

  public ValidationError(Error[] errors)
      : base(
          "General.Validation",
          "One or more validation errors occurred",
          ErrorType.Validation)
  {
    _errors = new ReadOnlyCollection<Error>(errors);
  }

  public ReadOnlyCollection<Error> Errors => _errors;
}
