// <copyright file="MeetTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using Name = WLCS.Modules.Competitions.Domain.Meets.ValueObjects.Name;

namespace WLCS.Modules.Competitions.UnitTests.Meets;

public class MeetTests : BaseTest
{
  [Fact]
  public void CreateMeet_ShouldRaiseDomainEvent_WhenMeetIsCreated()
  {
    // Arrange
    var name = Name.Create(Faker.Lorem.Word());
    var location = Location.Create(Faker.Address.City(), Faker.Address.State());
    var venue = Venue.Create(Faker.Company.CompanyName());
    var startDate = DateOnly.FromDateTime(Faker.Date.Recent());
    var endDate = DateOnly.FromDateTime(Faker.Date.Future());

    // Act
    var meet = Meet.Create(
      name.Value,
      location.Value,
      venue.Value,
      startDate,
      endDate);

    var domainEvent = AssertDomainEventWasPublished<MeetCreatedDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void CreateMeet_ShouldReturnFailure_WhenEndDatePrecedesStartDate()
  {
    // Arrange
    var name = Name.Create(Faker.Lorem.Word());
    var location = Location.Create(Faker.Address.City(), Faker.Address.State());
    var venue = Venue.Create(Faker.Company.CompanyName());
    var startDate = DateOnly.FromDateTime(Faker.Date.Recent());
    var endDate = DateOnly.FromDateTime(Faker.Date.Past());

    // Act
    var result = Meet.Create(
      name.Value,
      location.Value,
      venue.Value,
      startDate,
      endDate);

    // Assert
    result.IsSuccess.Should().BeFalse();
    result.Errors[0].Should().Be(MeetErrors.EndDatePrecedesStartDate);
  }

  [Fact]
  public void Archive_ShouldRaiseDomainEvent_WhenMeetIsArchived()
  {
    // Arrange
    var meet = Meet.Create(
      Name.Create(Faker.Lorem.Word()).Value,
      Location.Create(Faker.Address.City(), Faker.Address.State()).Value,
      Venue.Create(Faker.Company.CompanyName()).Value,
      DateOnly.FromDateTime(Faker.Date.Recent()),
      DateOnly.FromDateTime(Faker.Date.Future())).Value;

    // Act
    meet.ArchiveMeet();

    var domainEvent = AssertDomainEventWasPublished<MeetArchivedDomainEvent>(meet);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Id.Value);
  }

  [Fact]
  public void AddCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsAdded()
  {
    // Arrange
    var meet = Meet.Create(
      Name.Create(Faker.Lorem.Word()).Value,
      Location.Create(Faker.Address.City(), Faker.Address.State()).Value,
      Venue.Create(Faker.Company.CompanyName()).Value,
      DateOnly.FromDateTime(Faker.Date.Recent()),
      DateOnly.FromDateTime(Faker.Date.Future())).Value;

    var competition = Competition.Create(
      MeetId.Create(meet.Id.Value),
      Domain.Competitions.ValueObjects.Name.Create(Faker.Company.CompanyName()).Value,
      Scope.FromValue(Faker.Random.Number(0, 1)),
      CompetitionType.FromValue(Faker.Random.Number(0, 2)),
      AgeDivision.FromValue(Faker.Random.Number(0, 6)));

    // Act
    meet.AddCompetition(competition);

    var domainEvent = AssertDomainEventWasPublished<CompetitionAddedToMeetDomainEvent>(meet);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Id.Value);
    domainEvent.CompetitionId.Should().Be(competition.Id.Value);
  }

  [Fact]
  public void RemoveCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsRemoved()
  {
    // Arrange
    var meet = Meet.Create(
      Name.Create(Faker.Lorem.Word()).Value,
      Location.Create(Faker.Address.City(), Faker.Address.State()).Value,
      Venue.Create(Faker.Company.CompanyName()).Value,
      DateOnly.FromDateTime(Faker.Date.Recent()),
      DateOnly.FromDateTime(Faker.Date.Future())).Value;

    var competition = Competition.Create(
      MeetId.Create(meet.Id.Value),
      Domain.Competitions.ValueObjects.Name.Create(Faker.Company.CompanyName()).Value,
      Scope.FromValue(Faker.Random.Number(0, 1)),
      CompetitionType.FromValue(Faker.Random.Number(0, 2)),
      AgeDivision.FromValue(Faker.Random.Number(0, 6)));

    meet.AddCompetition(competition);

    // Act
    meet.RemoveCompetition(competition);

    var domainEvent = AssertDomainEventWasPublished<CompetitionRemovedFromMeetDomainEvent>(meet);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Id.Value);
    domainEvent.CompetitionId.Should().Be(competition.Id.Value);
  }

  [Fact]
  public void AddAthlete_ShouldRaiseDomainEvent_WhenAthleteIsAddedToCompetition()
  {
    // Arrange
    var meet = Meet.Create(
      Name.Create(Faker.Lorem.Word()).Value,
      Location.Create(Faker.Address.City(), Faker.Address.State()).Value,
      Venue.Create(Faker.Company.CompanyName()).Value,
      DateOnly.FromDateTime(Faker.Date.Recent()),
      DateOnly.FromDateTime(Faker.Date.Future())).Value;

    var athlete = Athlete.Create(
      Faker.Random.Guid(),
      Faker.Random.Number(5, 6).ToString(CultureInfo.InvariantCulture),
      Faker.Name.FirstName(),
      Faker.Name.LastName(),
      Faker.Date.PastDateOnly(),
      Gender.FromValue(Faker.Random.Number(0, 1)));

    // Act
    meet.AddAthleteToMeet(athlete);

    var domainEvent = AssertDomainEventWasPublished<AthleteAddedToMeetDomainEvent>(meet);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Id.Value);
  }
}
