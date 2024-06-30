// <copyright file="ModuleTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.ArchitectureTests.Layers;

/// <summary>
/// Tests for the modules.
/// </summary>
public class ModuleTests : BaseTest
{
  /// <summary>
  /// Checks that the administration module does not have any dependencies on other modules.
  /// </summary>
  [Fact]
  public void AdministrationModule_ShouldNotHaveDependencyOn_AnyOtherModule()
  {
    string[] otherModules = [AthletesNamespace, CommunicationNamespace, CompetitionNamespace, ResultsNamespace, SchedulingNamespace];
    string[] integrationEventsModules =
    [
      AthletesIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace,
      CompetitionIntegrationEventsNamespace,
      ResultsIntegrationEventsNamespace,
      SchedulingIntegrationEventsNamespace,
    ];

    List<Assembly> administartionAssemblies =
      [
        typeof(User).Assembly,
        Modules.Administration.Application.AssemblyReference.Application,
        Modules.Administration.Presentation.AssemblyReference.Presentation,
        typeof(AdministrationModule).Assembly
      ];

    Types.InAssemblies(administartionAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Checks that the athletes module does not have any dependencies on other modules.
  /// </summary>
  [Fact]
  public void AthletesModule_ShouldNotHaveDependencyOn_AnyOtherModule()
  {
    string[] otherModules = [AdministrationNamespace, CommunicationNamespace, CompetitionNamespace, ResultsNamespace, SchedulingNamespace];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace,
      CompetitionIntegrationEventsNamespace,
      ResultsIntegrationEventsNamespace,
      SchedulingIntegrationEventsNamespace,
    ];

    List<Assembly> athletesAssemblies =
      [
        Modules.Athletes.Application.AssemblyReference.Application,
        Modules.Athletes.Presentation.AssemblyReference.Presentation,
        typeof(AthletesModule).Assembly
      ];

    Types.InAssemblies(athletesAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Checks that the communication module does not have any dependencies on other modules.
  /// </summary>
  [Fact]
  public void CommunicationModule_ShouldNotHaveDependencyOn_AnyOtherModule()
  {
    string[] otherModules = [AdministrationNamespace, AthletesNamespace, CompetitionNamespace, ResultsNamespace, SchedulingNamespace];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace,
      CompetitionIntegrationEventsNamespace,
      ResultsIntegrationEventsNamespace,
      SchedulingIntegrationEventsNamespace,
    ];

    List<Assembly> communicationAssemblies =
      [
        Modules.Communication.Application.AssemblyReference.Application,
        Modules.Communication.Presentation.AssemblyReference.Presentation,
        typeof(CommunicationModule).Assembly
      ];

    Types.InAssemblies(communicationAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Checks that the results module does not have any dependencies on other modules.
  /// </summary>
  [Fact]
  public void CompetitionModule_ShouldNotHaveDependencyOn_AnyOtherModule()
  {
    string[] otherModules = [AdministrationNamespace, AthletesNamespace, CommunicationNamespace, ResultsNamespace, SchedulingNamespace];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace,
      ResultsIntegrationEventsNamespace,
      SchedulingIntegrationEventsNamespace,
    ];

    List<Assembly> competitionAssemblies =
      [
        typeof(Meet).Assembly,
        Modules.Competition.Application.AssemblyReference.Application,
        Modules.Competition.Presentation.AssemblyReference.Presentation,
        typeof(CompetitionModule).Assembly
      ];

    Types.InAssemblies(competitionAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Checks that the results module does not have any dependencies on other modules.
  /// </summary>
  [Fact]
  public void ResultsModule_ShouldNotHaveDependencyOn_AnyOtherModule()
  {
    string[] otherModules = [AdministrationNamespace, AthletesNamespace, CommunicationNamespace, CompetitionNamespace, SchedulingNamespace];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace,
      CompetitionIntegrationEventsNamespace,
      SchedulingIntegrationEventsNamespace,
    ];

    List<Assembly> resultsAssemblies =
      [
        Modules.Results.Application.AssemblyReference.Application,
        Modules.Results.Presentation.AssemblyReference.Presentation,
        typeof(ResultsModule).Assembly
      ];

    Types.InAssemblies(resultsAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  /// <summary>
  /// Checks that the scheduling module does not have any dependencies on other modules.
  /// </summary>
  [Fact]
  public void SchedulingModule_ShouldNotHaveDependencyOn_AnyOtherModule()
  {
    string[] otherModules = [AdministrationNamespace, AthletesNamespace, CommunicationNamespace, CompetitionNamespace, ResultsNamespace];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace,
      CompetitionIntegrationEventsNamespace,
      ResultsIntegrationEventsNamespace,
    ];

    List<Assembly> schedulingAssemblies =
      [
        Modules.Scheduling.Application.AssemblyReference.Application,
        Modules.Scheduling.Presentation.AssemblyReference.Presentation,
        typeof(SchedulingModule).Assembly
      ];

    Types.InAssemblies(schedulingAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }
}
