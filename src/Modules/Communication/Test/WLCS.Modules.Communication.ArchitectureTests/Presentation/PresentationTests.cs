// <copyright file="PresentationTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.ArchitectureTests.Presentation;

public class PresentationTests : BaseTest
{
  [Fact]
  public void IntegrationEventHandler_Should_BeSealed()
  {
    Types.InAssembly(PresentationAssembly)
      .That()
      .Inherit(typeof(IConsumer<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void IntegrationEventHandler_ShouldHave_NameEndingWith_IntegrationEventHandler()
  {
    Types.InAssembly(PresentationAssembly)
      .That()
      .Inherit(typeof(IConsumer<>))
      .Should()
      .HaveNameEndingWith("IntegrationEventConsumer", StringComparison.InvariantCulture)
      .GetResult()
      .ShouldBeSuccessful();
  }
}
