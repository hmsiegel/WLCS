// <copyright file="AthleteUtils.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.UnitTests.Athletes;

internal sealed class AthleteUtils : BaseTest
{
  public static Result<Athlete> CreateAthlete()
  {
    return Athlete.Create(
      Faker.Random.Guid(),
      Faker.Random.Number(5, 6).ToString(CultureInfo.InvariantCulture),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Faker.Date.PastDateOnly(),
      Gender.FromValue(Faker.Random.Number(0, 1)));
  }
}
