// <copyright file="NotFoundException.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.Infrastructure.Identity;

/// <summary>
/// Represents an exception that is thrown when a requested resource is not found.
/// </summary>
[Serializable]
public class NotFoundException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="NotFoundException"/> class.
  /// </summary>
  public NotFoundException()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="NotFoundException"/> class.
  /// </summary>
  /// <param name="message">The error message.</param>
  public NotFoundException(string? message)
    : base(message)
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="NotFoundException"/> class.
  /// </summary>
  /// <param name="message">The error message.</param>
  /// <param name="innerException">The inner exception.</param>
  public NotFoundException(string? message, Exception? innerException)
    : base(message, innerException)
  {
  }
}
