﻿// <copyright file="Result.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public class Result
{
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

  public bool IsSuccess { get; }

  public bool IsFailure => !IsSuccess;

  public Error Error { get; }

  public static Result Success() => new(true, Error.None);

  public static Result<TValue> Success<TValue>(TValue value) =>
      new(value, true, Error.None);

  public static Result Failure(Error error) => new(false, error);

  public static Result<TValue> Failure<TValue>(Error error) =>
      new(default, false, error);
}
