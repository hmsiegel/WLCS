// <copyright file="MeetTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.UnitTests.Meets;

public class MeetTests : BaseTest
{
  [Fact]
  public void CreateMeet_ShouldRaiseDomainEvent_WhenMeetIsCreated()
  {
    // Act
    var meet = MeetUtils.CreateMeet();

    var domainEvent = AssertDomainEventWasPublished<MeetCreatedDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void CreateMeet_ShouldReturnFailure_WhenEndDatePrecedesStartDate()
  {
    var result = MeetUtils.CreateMeet();

    // Assert
    result.IsSuccess.Should().BeFalse();
    result.Errors[0].Should().Be(MeetErrors.EndDatePrecedesStartDate);
  }

  [Fact]
  public void Archive_ShouldRaiseDomainEvent_WhenMeetIsArchived()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    // Act
    meet.Value.ArchiveMeet();

    var domainEvent = AssertDomainEventWasPublished<MeetArchivedDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void AddCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsAdded()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var competition = CompetitionUtils.CreateCompetition(meet.Value);

    // Act
    meet.Value.AddCompetition(competition.Value);

    var domainEvent = AssertDomainEventWasPublished<CompetitionAddedToMeetDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
    domainEvent.CompetitionId.Should().Be(competition.Value.Id.Value);
  }

  [Fact]
  public void AddCompetition_ShouldReturnFailure_WhenCompetitionIsAlreadyAdded()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var competition = CompetitionUtils.CreateCompetition(meet.Value);

    // Act
    meet.Value.AddCompetition(competition.Value);

    var result = meet.Value.AddCompetition(competition.Value);

    // Assert
    result.IsSuccess.Should().BeFalse();
    result.Errors[0].Should().Be(MeetErrors.CompetitionAlreadyAdded);
  }

  [Fact]
  public void RemoveCompetition_ShouldRaiseDomainEvent_WhenCompetitionIsRemoved()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var competition = CompetitionUtils.CreateCompetition(meet.Value);

    meet.Value.AddCompetition(competition.Value);

    // Act
    meet.Value.RemoveCompetition(competition.Value);

    var domainEvent = AssertDomainEventWasPublished<CompetitionRemovedFromMeetDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void AddAthlete_ShouldRaiseDomainEvent_WhenAthleteIsAddedToMeet()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var athlete = AthleteUtils.CreateAthlete();

    // Act
    meet.Value.AddAthlete(athlete.Value);

    var domainEvent = AssertDomainEventWasPublished<AthleteAddedToMeetDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void RemoveAthlete_ShouldRaiseDomainEvent_WhenAthleteIsRemovedFromMeet()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var athlete = AthleteUtils.CreateAthlete();

    // Act
    meet.Value.AddAthlete(athlete.Value);

    meet.Value.RemoveAthlete(athlete.Value);

    var domainEvent = AssertDomainEventWasPublished<AthleteRemovedFromMeetDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void AddAthlete_ShouldReturnFailure_WhenAthleteIsAlreadyAddedToMeet()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var athlete = AthleteUtils.CreateAthlete();

    // Act
    meet.Value.AddAthlete(athlete.Value);

    var result = meet.Value.AddAthlete(athlete.Value);

    // Assert
    result.IsSuccess.Should().BeFalse();
    result.Errors[0].Should().Be(MeetErrors.AthleteAlreadyAdded);
  }

  [Fact]
  public void AddPlatform_ShouldRaiseDomainEvent_WhenPlatformIsAddedToMeet()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var platform = PlatformUtils.CreatePlatform(meet.Value);

    // Act
    meet.Value.AddPlatform(platform.Value);

    var domainEvent = AssertDomainEventWasPublished<PlatformAddedToMeetDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
    domainEvent.PlatformId.Should().Be(platform.Value.Id.Value);
  }

  [Fact]
  public void AddPlatform_ShouldReturnFailure_WhenPlatformIsAlreadyAddedToMeet()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var platform = PlatformUtils.CreatePlatform(meet.Value);

    // Act
    meet.Value.AddPlatform(platform.Value);

    var result = meet.Value.AddPlatform(platform.Value);

    // Assert
    result.IsSuccess.Should().BeFalse();
    result.Errors[0].Should().Be(MeetErrors.PlatformAlreadyAdded);
  }

  [Fact]
  public void RemovePlatform_ShouldRaiseDomainEvent_WhenPlatformIsRemovedFromMeet()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var platform = PlatformUtils.CreatePlatform(meet.Value);

    // Act
    meet.Value.AddPlatform(platform.Value);

    meet.Value.RemovePlatform(platform.Value);

    var domainEvent = AssertDomainEventWasPublished<PlatformRemovedFromMeetDomainEvent>(meet.Value);

    // Assert
    domainEvent.MeetId.Should().Be(meet.Value.Id.Value);
  }

  [Fact]
  public void RemovePlatform_ShouldReturnFailure_WhenPlatformDoesNotExist()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var platform = PlatformUtils.CreatePlatform(meet.Value);

    // Act
    var result = meet.Value.RemovePlatform(platform.Value);

    result.Errors[0].Should().Be(MeetErrors.PlatformNotFound(platform.Value.Id.Value));
  }

  [Fact]
  public void RemoveCompetition_ShouldReturnFailure_WhenCompetitionDoesNotExist()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var competition = CompetitionUtils.CreateCompetition(meet.Value);

    // Act
    var result = meet.Value.RemoveCompetition(competition.Value);

    result.Errors[0].Should().Be(MeetErrors.CompetitionNotFound(competition.Value.Id.Value));
  }

  [Fact]
  public void RemoveAthlete_ShouldReturnFailure_WhenAthleteDoesNotExist()
  {
    // Arrange
    var meet = MeetUtils.CreateMeet();

    var athlete = AthleteUtils.CreateAthlete();

    // Act
    var result = meet.Value.RemoveAthlete(athlete.Value);

    result.Errors[0].Should().Be(MeetErrors.AthleteNotFound(athlete.Value.Id));
  }
}
