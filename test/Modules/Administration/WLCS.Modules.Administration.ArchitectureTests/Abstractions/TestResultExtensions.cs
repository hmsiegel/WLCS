// <copyright file="TestResultExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using NetArchTest.Rules;

namespace WLCS.Modules.Administration.ArchitectureTests.Abstractions;

/// <summary>
/// Extension methods for <see cref="TestResult"/>.
/// </summary>
internal static class TestResultExtensions
{
  /// <summary>
  /// Method to assert that the test result is successful.
  /// </summary>
  /// <param name="testResult">The result.</param>
  internal static void ShouldBeSuccessful(this TestResult testResult)
  {
    testResult.FailingTypes?.Should().BeEmpty();
  }
}
