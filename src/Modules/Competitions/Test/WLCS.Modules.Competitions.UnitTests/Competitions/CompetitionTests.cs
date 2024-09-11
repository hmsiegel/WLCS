// <copyright file="CompetitionTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using Name = WLCS.Modules.Competitions.Domain.Competitions.ValueObjects.Name;

namespace WLCS.Modules.Competitions.UnitTests.Competitions;

public class CompetitionTests : BaseTest
{
  [Fact]
  public void CreateCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsCreated()
  {
    // Arrange
    var meetId = MeetId.Create(Faker.Random.Guid());
    var name = Name.Create(Faker.Lorem.Word());
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
}
