// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.ArchitectureTests.Abstractions;

/// <summary>
/// Base class for all tests.
/// </summary>
public abstract class BaseTest
{
  /// <summary>
  /// Represents the Application project.
  /// </summary>
  protected static readonly Assembly ApplicationAssembly = typeof(Competition.Application.AssemblyReference).Assembly;

  /// <summary>
  /// Represents the Domain project.
  /// </summary>
  protected static readonly Assembly DomainAssembly = typeof(Meet).Assembly;

  /// <summary>
  /// Represents the Infrastructure project.
  /// </summary>
  protected static readonly Assembly InfrastructureAssembly = typeof(CompetitionModule).Assembly;

  /// <summary>
  /// Represents the Presentation project.
  /// </summary>
  protected static readonly Assembly PresentationAssembly = typeof(Competition.Presentation.AssemblyReference).Assembly;
}
