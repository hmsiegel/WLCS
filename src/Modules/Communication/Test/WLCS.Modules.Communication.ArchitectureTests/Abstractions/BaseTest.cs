// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
  protected static readonly Assembly ApplicationAssembly = typeof(Communication.Application.AssemblyReference).Assembly;
  protected static readonly Assembly InfrastructureAssembly = typeof(CommunicationModule).Assembly;
  protected static readonly Assembly PresentationAssembly = typeof(Communication.Presentation.AssemblyReference).Assembly;
}
