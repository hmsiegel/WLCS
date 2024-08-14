// <copyright file="WlcsException.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Exceptions;

public sealed class WlcsException(
  string requestName,
  Error? error = default,
  Exception? innerException = default)
  : Exception("Application exception", innerException)
{
  public string RequestName { get; } = requestName;

  public Error? Error { get; } = error;
}
