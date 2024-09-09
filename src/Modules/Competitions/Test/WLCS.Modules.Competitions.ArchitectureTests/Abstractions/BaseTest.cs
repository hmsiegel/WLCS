// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(Competitions.Application.AssemblyReference).Assembly;
    protected static readonly Assembly DomainAssembly = typeof(Meet).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(CompetitionModule).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Competitions.Presentation.AssemblyReference).Assembly;
}
