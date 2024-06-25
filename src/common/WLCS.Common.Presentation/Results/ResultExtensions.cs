// <copyright file="ResultExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Presentation.Results;

/// <summary>
/// Represents extension methods for <see cref="Result"/> and <see cref="Result{T}"/>.
/// </summary>
public static class ResultExtensions
{
  /// <summary>
  /// Matches the result to the appropriate function.
  /// </summary>
  /// <typeparam name="TOut">The type of the result.</typeparam>
  /// <param name="result">The result to check..</param>
  /// <param name="onSuccess">A function if the result is a success.</param>
  /// <param name="onFailure">A function if the result is a failure.</param>
  /// <returns>The result.</returns>
  public static TOut Match<TOut>(
      this Result result,
      Func<TOut> onSuccess,
      Func<Result, TOut> onFailure)
  {
    ArgumentNullException.ThrowIfNull(result, nameof(result));
    ArgumentNullException.ThrowIfNull(onSuccess, nameof(onSuccess));
    ArgumentNullException.ThrowIfNull(onFailure, nameof(onFailure));

    return result.IsSuccess ? onSuccess() : onFailure(result);
  }

  /// <summary>
  /// Matches the result to the appropriate function.
  /// </summary>
  /// <typeparam name="TIn">The type being passed in.</typeparam>
  /// <typeparam name="TOut">The type of the result.</typeparam>
  /// <param name="result">The result to check..</param>
  /// <param name="onSuccess">A function if the result is a success.</param>
  /// <param name="onFailure">A function if the result is a failure.</param>
  /// <returns>The result.</returns>
  public static TOut Match<TIn, TOut>(
      this Result<TIn> result,
      Func<TIn, TOut> onSuccess,
      Func<Result<TIn>, TOut> onFailure)
  {
    ArgumentNullException.ThrowIfNull(result, nameof(result));
    ArgumentNullException.ThrowIfNull(onSuccess, nameof(onSuccess));
    ArgumentNullException.ThrowIfNull(onFailure, nameof(onFailure));

    return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
  }
}
