// <copyright file="BaseTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.ArchitectureTests.Abstractions;

/// <summary>
/// Base class for all tests.
/// </summary>
public abstract class BaseTest
{
  /// <summary>
  /// Namespace for the Administration module.
  /// </summary>
  protected const string AdministrationNamespace = "WLCS.Modules.Administration";

  /// <summary>
  /// Namespace for the Administration Integration Events project.
  /// </summary>
  protected const string AdministrationIntegrationEventsNamespace = "WLCS.Modules.Administration.IntegrationEvents";

  /// <summary>
  /// Namespace for the Athletes module.
  /// </summary>
  protected const string AthletesNamespace = "WLCS.Modules.Athletes";

  /// <summary>
  /// Namespace for the Athletes Integration Events project.
  /// </summary>
  protected const string AthletesIntegrationEventsNamespace = "WLCS.Modules.Athletes.IntegrationEvents";

  /// <summary>
  /// Namespace for the Communication module.
  /// </summary>
  protected const string CommunicationNamespace = "WLCS.Modules.Communication";

  /// <summary>
  /// Namespace for the Communication Integration Events project.
  /// </summary>
  protected const string CommunicationIntegrationEventsNamespace = "WLCS.Modules.Communication.IntegrationEvents";

  /// <summary>
  /// Namespace for the Competition module.
  /// </summary>
  protected const string CompetitionNamespace = "WLCS.Modules.Competition";

  /// <summary>
  /// Namespace for the Competition Integration Events project.
  /// </summary>
  protected const string CompetitionIntegrationEventsNamespace = "WLCS.Modules.Competition.IntegrationEvents";

  /// <summary>
  /// Namespace for the Results module.
  /// </summary>
  protected const string ResultsNamespace = "WLCS.Modules.Results";

  /// <summary>
  /// Namespace for the Results Integration Events project.
  /// </summary>
  protected const string ResultsIntegrationEventsNamespace = "WLCS.Modules.Results.IntegrationEvents";

  /// <summary>
  /// Namespace for the Scheduling module.
  /// </summary>
  protected const string SchedulingNamespace = "WLCS.Modules.Scheduling";

  /// <summary>
  /// Namespace for the Scheduling Integration Events project.
  /// </summary>
  protected const string SchedulingIntegrationEventsNamespace = "WLCS.Modules.Scheduling.IntegrationEvents";
}
