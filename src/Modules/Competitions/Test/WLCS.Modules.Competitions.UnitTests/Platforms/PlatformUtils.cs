// <copyright file="PlatformUtils.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.UnitTests.Platforms;

internal sealed class PlatformUtils : BaseTest
{
  public static Result<Platform> CreatePlatform(Meet meet)
  {
    return Platform.Create(
      meet.Id,
      PlatformName.Create(Faker.Lorem.Word()).Value);
  }
}
