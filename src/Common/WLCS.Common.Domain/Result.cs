// <copyright file="Result.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public class Result
{
  protected internal Result(bool isSuccess, Error error)
  {
    if ((isSuccess && error != Error.None) ||
        (!isSuccess && error == Error.None))
    {
      throw new ArgumentException("Invalid error", nameof(error));
    }

    IsSuccess = isSuccess;
    Errors = [error];
  }

  protected internal Result(bool isSuccess, Error[] errors)
  {
    IsSuccess = isSuccess;
    Errors = errors;
  }

  public bool IsSuccess { get; }

  public bool IsFailure => !IsSuccess;

  [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Reviewed")]
  public Error[] Errors { get; }

  public static Result Success() => new(true, Error.None);

  public static Result<TValue> Success<TValue>(TValue value) =>
      new(value, true, Error.None);

  public static Result Failure(Error error) => new(false, error);

  public static Result Failure(Error[] errors) => new(false, errors);

  public static Result<TValue> Failure<TValue>(Error error) =>
      new(default, false, error);

  public static Result<TValue> Failure<TValue>(Error[] errors) =>
      new(default, false, errors);

  public static Result<TValue> Create<TValue>(TValue? value)
  {
    return value is not null
      ? Success(value)
      : Failure<TValue>(Error.NullValue);
  }

  public static Result<T> Ensure<T>(T value, Func<T, bool> predicate, Error error)
  {
    ArgumentNullException.ThrowIfNull(predicate);

    return predicate(value)
        ? Success(value)
        : Failure<T>(error);
  }

  public static Result<T> Ensure<T>(T value, params (Func<T, bool> Predicate, Error Error)[] functions)
  {
    ArgumentNullException.ThrowIfNull(functions);

    var results = new List<Result<T>>();
    foreach ((Func<T, bool> predicate, Error error) in functions)
    {
      results.Add(Ensure(value, predicate, error));
    }

    return Combine(results.ToArray());
  }

  public static Result<T> Combine<T>(params Result<T>[] results)
  {
    ArgumentNullException.ThrowIfNull(results);

    if (Array.Exists(results, r => r.IsFailure))
    {
      return Failure<T>(results.SelectMany(r => r.Errors).Distinct().ToArray());
    }

    return Success(results[0].Value);
  }

  [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1414:Tuple types in signatures should have element names", Justification = "Reviewed")]
  public static Result<(T1, T2)> Combine<T1, T2>(Result<T1> result1, Result<T2> result2)
  {
    ArgumentNullException.ThrowIfNull(result1);
    ArgumentNullException.ThrowIfNull(result2);

    if (result1.IsFailure)
    {
      return Failure<(T1, T2)>(result1.Errors);
    }

    if (result2.IsFailure)
    {
      return Failure<(T1, T2)>(result2.Errors);
    }

    return Success((result1.Value, result2.Value));
  }
}
