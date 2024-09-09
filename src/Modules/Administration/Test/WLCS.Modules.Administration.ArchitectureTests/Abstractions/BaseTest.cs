// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
  protected static readonly Assembly ApplicationAssembly = typeof(Administration.Application.AssemblyReference).Assembly;
  protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
  protected static readonly Assembly InfrastructureAssembly = typeof(AdministrationModule).Assembly;
  protected static readonly Assembly PresentationAssembly = typeof(Administration.Presentation.AssemblyReference).Assembly;
}
