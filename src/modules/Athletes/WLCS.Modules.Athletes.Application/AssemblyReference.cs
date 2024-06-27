// <copyright file="AssemblyReference.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.Application;

/// <summary>
/// A class to reference the assembly.
/// </summary>
public static class AssemblyReference
{
  /// <summary>
  /// The application assembly.
  /// </summary>
  public static readonly Assembly Application = typeof(AssemblyReference).Assembly;
}
