// <copyright file="Error.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents an error.
/// </summary>
#pragma warning disable CA1716 // Identifiers should not match keywords
public record Error
#pragma warning restore CA1716 // Identifiers should not match keywords
{
  /// <summary>
  /// Represents an empty error.
  /// </summary>
  public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

  /// <summary>
  /// Represents a null value error.
  /// </summary>
  public static readonly Error NullValue = new(
      "General.Null",
      "Null value was provided",
      ErrorType.Failure);

  /// <summary>
  /// Initializes a new instance of the <see cref="Error"/> class.
  /// </summary>
  /// <param name="code">The error code.</param>
  /// <param name="description">The error description.</param>
  /// <param name="type">The error type.</param>
  public Error(string code, string description, ErrorType type)
  {
    Code = code;
    Description = description;
    Type = type;
  }

  /// <summary>
  /// Gets the error code.
  /// </summary>
  public string Code { get; }

  /// <summary>
  /// Gets the error description.
  /// </summary>
  public string Description { get; }

  /// <summary>
  /// Gets the error type.
  /// </summary>
  public ErrorType Type { get; }

  /// <summary>
  /// Represents an error of type failure.
  /// </summary>
  /// <param name="code">The error code.</param>
  /// <param name="description">The error description.</param>
  /// <returns>The error.</returns>
  public static Error Failure(string code, string description) =>
      new(code, description, ErrorType.Failure);

  /// <summary>
  /// Represents an error of type not found.
  /// </summary>
  /// <param name="code">The error code.</param>
  /// <param name="description">The error description.</param>
  /// <returns>The error.</returns>
  public static Error NotFound(string code, string description) =>
      new(code, description, ErrorType.NotFound);

  /// <summary>
  /// Represents an error of type problem.
  /// </summary>
  /// <param name="code">The error code.</param>
  /// <param name="description">The error description.</param>
  /// <returns>The error.</returns>
  public static Error Problem(string code, string description) =>
      new(code, description, ErrorType.Problem);

  /// <summary>
  /// Represents an error of type conflict.
  /// </summary>
  /// <param name="code">The error code.</param>
  /// <param name="description">The error description.</param>
  /// <returns>The error.</returns>
  public static Error Conflict(string code, string description) =>
      new(code, description, ErrorType.Conflict);
}
