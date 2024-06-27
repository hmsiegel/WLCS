// <copyright file="AssemblyReference.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Presentation;

/// <summary>
/// A class to reference the assembly.
/// </summary>
public static class AssemblyReference
{
  /// <summary>
  /// The application assembly.
  /// </summary>
  public static readonly Assembly Presentation = typeof(AssemblyReference).Assembly;
}
