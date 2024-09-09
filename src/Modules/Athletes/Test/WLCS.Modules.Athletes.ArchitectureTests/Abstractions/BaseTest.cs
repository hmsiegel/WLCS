// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
  protected static readonly Assembly ApplicationAssembly = typeof(Athletes.Application.AssemblyReference).Assembly;
  protected static readonly Assembly DomainAssembly = typeof(Athlete).Assembly;
  protected static readonly Assembly InfrastructureAssembly = typeof(AthletesModule).Assembly;
  protected static readonly Assembly PresentationAssembly = typeof(Athletes.Presentation.AssemblyReference).Assembly;
}
