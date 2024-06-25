// <copyright file="ErrorType.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

/// <summary>
/// Represents the type of error.
/// </summary>
public enum ErrorType
{
  /// <summary>
  /// A failure error type.
  /// </summary>
  Failure = 0,

  /// <summary>
  /// A validation error type.
  /// </summary>
  Validation = 1,

  /// <summary>
  /// A problem error type.
  /// </summary>
  Problem = 2,

  /// <summary>
  /// A not found error type.
  /// </summary>
  NotFound = 3,

  /// <summary>
  /// A conflict error type.
  /// </summary>
  Conflict = 4,
}
