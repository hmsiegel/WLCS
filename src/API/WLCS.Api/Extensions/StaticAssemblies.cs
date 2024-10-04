// <copyright file="StaticAssemblies.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Extensions;

public static class StaticAssemblies
{
  internal static Assembly[] PresentationAssemblies =>
    [
      Modules.Competitions.Presentation.AssemblyReference.Assembly,
      Modules.Administration.Presentation.AssemblyReference.Assembly,
      Modules.Athletes.Presentation.AssemblyReference.Assembly,
      Modules.Communication.Presentation.AssemblyReference.Assembly,
    ];

  internal static Assembly[] ApplicationAssemblies =>
    [
      Modules.Competitions.Application.AssemblyReference.Assembly,
      Modules.Administration.Application.AssemblyReference.Assembly,
      Modules.Athletes.Application.AssemblyReference.Assembly,
      Modules.Communication.Application.AssemblyReference.Assembly,
    ];
}
