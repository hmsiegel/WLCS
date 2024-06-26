﻿// <copyright file="Result.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents a result.
/// </summary>
public class Result
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Result"/> class.
  /// </summary>
  /// <param name="isSuccess">Indicates if the result was a success.</param>
  /// <param name="error">The error generated by the result.</param>
  public Result(bool isSuccess, Error error)
  {
    if ((isSuccess && error != Error.None) ||
        (!isSuccess && error == Error.None))
    {
      throw new ArgumentException("Invalid error", nameof(error));
    }

    IsSuccess = isSuccess;
    Error = error;
  }

  /// <summary>
  /// Gets a value indicating whether the result was a success.
  /// </summary>
  public bool IsSuccess { get; }

  /// <summary>
  /// Gets a value indicating whether the result was a failure.
  /// </summary>
  public bool IsFailure => !IsSuccess;

  /// <summary>
  /// Gets the error generated by the result.
  /// </summary>
  public Error Error { get; }

  /// <summary>
  /// Represents an empty success result.
  /// </summary>
  /// <returns>An empty result.</returns>
  public static Result Success() => new(true, Error.None);

  /// <summary>
  /// Represents a success result.
  /// </summary>
  /// <typeparam name="TValue">The type of the result..</typeparam>
  /// <param name="value">The value of the result.</param>
  /// <returns>A result.</returns>
  public static Result<TValue> Success<TValue>(TValue value) =>
      new(value, true, Error.None);

  /// <summary>
  /// Represents a failure result.
  /// </summary>
  /// <param name="error">The error.</param>
  /// <returns>A result.</returns>
  public static Result Failure(Error error) => new(false, error);

  /// <summary>
  /// Represents a failure result.
  /// </summary>
  /// <typeparam name="TValue">The type of the failure.</typeparam>
  /// <param name="error">The error generated by the result.</param>
  /// <returns>The result.</returns>
  public static Result<TValue> Failure<TValue>(Error error) =>
      new(default, false, error);
}
