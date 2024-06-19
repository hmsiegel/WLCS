// <copyright file="WLCSException.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Exceptions;

/// <summary>
/// Contains the exception for the WLCS application.
/// </summary>
public sealed class WLCSException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="WLCSException"/> class.
  /// </summary>
  /// <param name="requestName">The request name.</param>
  /// <param name="error">The error.</param>
  /// <param name="innerException">The inner exception.</param>
  public WLCSException(string requestName, Error? error = default, Exception? innerException = default)
      : base("Application exception", innerException)
  {
    RequestName = requestName;
    Error = error;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="WLCSException"/> class.
  /// </summary>
  public WLCSException()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="WLCSException"/> class.
  /// </summary>
  /// <param name="message">The message.</param>
  public WLCSException(string message)
    : base(message)
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="WLCSException"/> class.
  /// </summary>
  /// <param name="message">The message.</param>
  /// <param name="innerException">The inner exception.</param>
  public WLCSException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  /// <summary>
  /// Gets the request name.
  /// </summary>
  public string RequestName { get; } = string.Empty;

  /// <summary>
  /// Gets the error.
  /// </summary>
  public Error? Error { get; }
}
