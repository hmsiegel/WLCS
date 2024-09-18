// <copyright file="ModuleTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.ArchitectureTests.Layers;

public class ModuleTests : BaseTest
{
  [Fact]
  public void AdministrationModule_ShouldNotHaveDependecyOn_AnyOtherModule()
  {
    string[] otherModules =
    [
      CompetitionsNamespace,
      AthletesNamespace,
      CommunicationNamespace
    ];
    string[] integrationEventsModules =
    [
      CompetitionsIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace
    ];

    List<Assembly> administrationAssemblies =
    [
      typeof(User).Assembly,
      Modules.Administration.Application.AssemblyReference.Assembly,
      Modules.Administration.Presentation.AssemblyReference.Assembly,
      typeof(AdministrationModule).Assembly
    ];

    Types.InAssemblies(administrationAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void CompetitionsModule_ShouldNotHaveDependecyOn_AnyOtherModule()
  {
    string[] otherModules =
    [
      AdministrationNamespace,
      AthletesNamespace,
      CommunicationNamespace
    ];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace
    ];

    List<Assembly> competitionsAssemblies =
    [
      typeof(Meet).Assembly,
      Modules.Competitions.Application.AssemblyReference.Assembly,
      Modules.Competitions.Presentation.AssemblyReference.Assembly,
      typeof(CompetitionModule).Assembly
    ];

    Types.InAssemblies(competitionsAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }

  [Fact]
  public void AthletesModule_ShouldNotHaveDependecyOn_AnyOtherModule()
  {
    string[] otherModules =
    [
      AdministrationNamespace,
      CompetitionsNamespace,
      CommunicationNamespace
    ];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      CompetitionsIntegrationEventsNamespace,
      CommunicationIntegrationEventsNamespace
    ];

    List<Assembly> athletesAssemblies =
    [
      typeof(Athlete).Assembly,
      Modules.Athletes.Application.AssemblyReference.Assembly,
      Modules.Athletes.Presentation.AssemblyReference.Assembly,
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

  [Fact]
  public void CommunicationModule_ShouldNotHaveDependecyOn_AnyOtherModule()
  {
    string[] otherModules =
    [
      AdministrationNamespace,
      CompetitionsNamespace,
      AthletesNamespace
    ];
    string[] integrationEventsModules =
    [
      AdministrationIntegrationEventsNamespace,
      CompetitionsIntegrationEventsNamespace,
      AthletesIntegrationEventsNamespace
    ];

    List<Assembly> athletesAssemblies =
    [
      Modules.Communication.Application.AssemblyReference.Assembly,
      Modules.Communication.Presentation.AssemblyReference.Assembly,
      typeof(CommunicationModule).Assembly
    ];

    Types.InAssemblies(athletesAssemblies)
      .That()
      .DoNotHaveDependencyOnAny(integrationEventsModules)
      .Should()
      .NotHaveDependencyOnAny(otherModules)
      .GetResult()
      .ShouldBeSuccessful();
  }
}
