// <copyright file="ResultExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public static class ResultExtensions
{
  public static Result<T> Ensure<T>(
    this Result<T> result,
    Func<T, bool> predicate,
    Error errorMessage)
  {
    ArgumentNullException.ThrowIfNull(predicate);
    ArgumentNullException.ThrowIfNull(errorMessage);
    ArgumentNullException.ThrowIfNull(result);

    if (result.IsFailure)
    {
      return result;
    }

    return !predicate(result.Value)
      ? result
      : Result.Failure<T>(errorMessage);
  }

  public static Result<TOut> Map<TIn, TOut>(
    this Result<TIn> result,
    Func<TIn, TOut> mappingFunc)
  {
    ArgumentNullException.ThrowIfNull(result);
    ArgumentNullException.ThrowIfNull(mappingFunc);

    return result.IsSuccess
        ? Result.Success(mappingFunc(result.Value))
        : Result.Failure<TOut>(result.Errors);
  }

  public static async Task<Result> BindAsync<TIn>(
      this Result<TIn> result,
      Func<TIn, Task<Result>> bindingFunc)
  {
    ArgumentNullException.ThrowIfNull(result);
    ArgumentNullException.ThrowIfNull(bindingFunc);

    if (result.IsFailure)
    {
      return Result.Failure(result.Errors);
    }

    return await bindingFunc(result.Value);
  }

  public static async Task<Result<TOut>> BindAsync<TIn, TOut>(
      this Result<TIn> result,
      Func<TIn, Task<Result<TOut>>> bindingFunc)
  {
    ArgumentNullException.ThrowIfNull(result);
    ArgumentNullException.ThrowIfNull(bindingFunc);

    if (result.IsFailure)
    {
      return Result.Failure<TOut>(result.Errors);
    }

    return await bindingFunc(result.Value);
  }

  public static Result<TIn> Tap<TIn>(
      this Result<TIn> result,
      Action<TIn> action)
  {
    ArgumentNullException.ThrowIfNull(action);
    ArgumentNullException.ThrowIfNull(result);

    if (result.IsSuccess)
    {
      action(result.Value);
    }

    return result;
  }

  public static async Task<Result<TIn>> TapAsync<TIn>(
      this Result<TIn> result,
      Func<Task> func)
  {
    ArgumentNullException.ThrowIfNull(func);
    ArgumentNullException.ThrowIfNull(result);

    if (result.IsSuccess)
    {
      await func();
    }

    return result;
  }

  public static async Task<Result<TIn>> TapAsync<TIn>(
      this Task<Result<TIn>> resultTask,
      Func<TIn, Task> func)
  {
    ArgumentNullException.ThrowIfNull(func);
    ArgumentNullException.ThrowIfNull(resultTask);

    Result<TIn> result = await resultTask;

    if (result.IsSuccess)
    {
      await func(result.Value);
    }

    return result;
  }
}
