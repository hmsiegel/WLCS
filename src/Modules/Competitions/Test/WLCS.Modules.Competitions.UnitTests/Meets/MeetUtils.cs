// <copyright file="MeetUtils.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.UnitTests.Meets;

internal sealed class MeetUtils : BaseTest
{
  public static Result<Meet> CreateMeet()
  {
    var name = MeetName.Create(Faker.Lorem.Word());
    var location = Location.Create(Faker.Address.City(), Faker.Address.State());
    var venue = Venue.Create(Faker.Company.CompanyName());
    var startDate = DateOnly.FromDateTime(Faker.Date.Recent());
    var endDate = DateOnly.FromDateTime(Faker.Date.Future());

    return Meet.Create(
      name.Value,
      location.Value,
      venue.Value,
      startDate,
      endDate).Value;
  }
}
