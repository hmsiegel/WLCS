// <copyright file="PresentationTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.ArchitectureTests.Presentation;

/// <summary>
/// Tests for the Presentation layer.
/// </summary>
public class PresentationTests : BaseTest
{
  /// <summary>
  /// Asserts that the IntegrationEventConsumer class is not public.
  /// </summary>
  [Fact]
  public void IntegrationEventConsumer_Should_NotBePublic()
  {
    Types.InAssembly(PresentationAssembly)
      .That()
      .ImplementInterface(typeof(IIntegrationEventHandler<>))
      .Or()
      .Inherit(typeof(IntegrationEventHandler<>))
      .Should()
      .NotBePublic()
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that the IntegrationEventConsumer class should be sealed.
  /// </summary>
  [Fact]
  public void IntegrationEventConsumer_Should_BeSealed()
  {
    Types.InAssembly(PresentationAssembly)
      .That()
      .ImplementInterface(typeof(IIntegrationEventHandler<>))
      .Or()
      .Inherit(typeof(IntegrationEventHandler<>))
      .Should()
      .BeSealed()
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Asserts that the IntegrationEventConsumer class should end with IntegrationEventHandler.
  /// </summary>
  [Fact]
  public void IntegrationEventConsumer_ShouldHave_NameEndingWith_IntegrationEventHandler()
  {
    Types.InAssembly(PresentationAssembly)
      .That()
      .ImplementInterface(typeof(IIntegrationEventHandler<>))
      .Or()
      .Inherit(typeof(IntegrationEventHandler<>))
      .Should()
      .HaveNameEndingWith("IntegrationEventHandler", StringComparison.InvariantCultureIgnoreCase)
      .GetResult()
      .ShouldBeSuccessful();
  }
}
