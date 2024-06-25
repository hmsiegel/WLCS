// <copyright file="ValidationError.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents a validation error.
/// </summary>
public sealed record ValidationError : Error
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ValidationError"/> class.
  /// </summary>
  /// <param name="errors">An array of errors.</param>
  public ValidationError(Error[] errors)
    : base(
      "General.Validation",
      "One or more validation errors occurred.",
      ErrorType.Validation)
  {
    Errors = errors;
  }

  /// <summary>
  /// Gets the errors.
  /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
  public Error[] Errors { get; }
#pragma warning restore CA1819 // Properties should not return arrays

  /// <summary>
  /// Gets the error message.
  /// </summary>
  /// <param name="results">A list of results.</param>
  /// <returns>The validation error.</returns>
  public static ValidationError FromResults(IEnumerable<Result> results) =>
      new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}
