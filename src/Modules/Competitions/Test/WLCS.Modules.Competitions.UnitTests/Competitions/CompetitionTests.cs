// <copyright file="CompetitionTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Modules.Competitions.UnitTests.Meets;

namespace WLCS.Modules.Competitions.UnitTests.Competitions;

public class CompetitionTests : BaseTest
{
  [Fact]
  public void CreateCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsCreated()
  {
    // Arrange
    var meetId = MeetId.Create(Faker.Random.Guid());
    var name = CompetitionName.Create(Faker.Lorem.Word());
    var scope = Scope.FromValue(Faker.Random.Number(0, 1));
    var competitionType = CompetitionType.FromValue(Faker.Random.Number(0, 2));
    var ageDivision = AgeDivision.FromValue(Faker.Random.Number(0, 6));

    // Act
    var competition = Competition.Create(
      meetId: meetId,
      name: name.Value,
      scope,
      competitionType,
      ageDivision);

    var domainEvent = AssertDomainEventWasPublished<CompetitionCreatedDomainEvent>(competition);

    // Assert
    domainEvent.CompetitionId.Should().Be(competition.Id.Value);
  }

  [Fact]
  public void UpdateCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsUpdate()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();
    var competition = CompetitionUtils.CreateCompetition(meet.Value);

    // Act
    var result = competition.Value;
    result.Update(
      CompetitionName.Create(Faker.Lorem.Word()).Value,
      Scope.FromValue(Faker.Random.Number(0, 1)),
      CompetitionType.FromValue(Faker.Random.Number(0, 2)),
      AgeDivision.FromValue(Faker.Random.Number(0, 6)));

    var domainEvent = AssertDomainEventWasPublished<CompetitionUpdatedDomainEvent>(result);

    // Assert
    domainEvent.CompetitionId.Should().Be(result.Id.Value);
    domainEvent.MeetId.Should().Be(result.MeetId.Value);
  }
}
