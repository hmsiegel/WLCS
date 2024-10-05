// <copyright file="CompetitionUtils.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.UnitTests.Competitions;

internal sealed class CompetitionUtils : BaseTest
{
  public static Result<Competition> CreateCompetition(Meet meet)
  {
    return Competition.Create(
      MeetId.Create(meet.Id.Value),
      Domain.Competitions.ValueObjects.CompetitionName.Create(Faker.Company.CompanyName()).Value,
      Scope.FromValue(Faker.Random.Number(0, 1)),
      CompetitionType.FromValue(Faker.Random.Number(0, 2)),
      AgeDivision.FromValue(Faker.Random.Number(0, 6)));
  }
}
