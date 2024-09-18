﻿// <copyright file="LayerTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.ArchitectureTests.Layers;

public class LayerTests : BaseTest
{
  [Fact]
  public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastrucureLayer()
  {
    Types.InAssembly(ApplicationAssembly)
      .Should()
      .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
  {
    Types.InAssembly(ApplicationAssembly)
      .Should()
      .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void PresentationLayer_ShouldNotHaveDependencyOn_InfrastrucureLayer()
  {
    Types.InAssembly(PresentationAssembly)
      .Should()
      .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
      .GetResult()
      .ShouldBeSuccessful();
  }
}
