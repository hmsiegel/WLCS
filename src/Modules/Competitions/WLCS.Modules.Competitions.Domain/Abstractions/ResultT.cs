// <copyright file="ResultT.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.Domain.Abstractions;

public class Result<TValue> : Result
{
  private readonly TValue? _value;

  public Result(TValue? value, bool isSuccess, Error error)
      : base(isSuccess, error)
  {
    _value = value;
  }

  [NotNull]
  public TValue Value => IsSuccess
      ? _value!
      : throw new InvalidOperationException("The value of a failure result can't be accessed.");

  public static implicit operator Result<TValue>(TValue? value) =>
      value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

  public static Result<TValue> ValidationFailure(Error error) =>
      new(default, false, error);
}
