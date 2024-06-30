// <copyright file="LayerTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.ArchitectureTests.Layers;

/// <summary>
/// Tests the dependencies between the layers of the Administration module.
/// </summary>
public class LayerTests : BaseTest
{
  /// <summary>
  /// Tests that the Domain Layer should not have a dependency on the Application Layer.
  /// </summary>
  [Fact]
  public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
  {
    Types.InAssembly(DomainAssembly)
      .Should()
      .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Tests that the Domain Layer should not have a dependency on the Infrastructure Layer.
  /// </summary>
  [Fact]
  public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
  {
    Types.InAssembly(DomainAssembly)
      .Should()
      .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Tests that the Application Layer should not have a dependency on the Infrastructure Layer.
  /// </summary>
  [Fact]
  public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
  {
    Types.InAssembly(ApplicationAssembly)
      .Should()
      .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Tests that the Application Layer should not have a dependency on the Presentation Layer.
  /// </summary>
  [Fact]
  public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
  {
    Types.InAssembly(ApplicationAssembly)
      .Should()
      .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Tests that the Presentation Layer should not have a dependency on the Infrastructure Layer.
  /// </summary>
  [Fact]
  public void PresentationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
  {
    Types.InAssembly(PresentationAssembly)
      .Should()
      .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }
}
