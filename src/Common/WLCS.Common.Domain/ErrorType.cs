// <copyright file="ErrorType.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Domain;

public enum ErrorType
{
  Failure = 0,
  Validation = 1,
  Problem = 2,
  NotFound = 3,
  Conflict = 4,
}
