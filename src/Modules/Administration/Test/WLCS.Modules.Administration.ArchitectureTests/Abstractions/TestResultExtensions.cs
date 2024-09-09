// <copyright file="TestResultExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
  internal static void ShouldBeSuccessful(this TestResult testResult)
  {
    testResult.FailingTypes?.Should().BeEmpty();
  }
}
