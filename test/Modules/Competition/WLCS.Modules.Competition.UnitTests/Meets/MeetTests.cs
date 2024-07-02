// <copyright file="MeetTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competition.UnitTests.Meets;

/// <summary>
/// Tests for the <see cref="Meet"/> class.
/// </summary>
public class MeetTests : BaseTest
{
  /// <summary>
  /// Asserts that the end date should not precede the start date.
  /// </summary>
  [Fact]
  public void Create_ShouldReturnFailure_WhenEndDatePrecedesStartDate()
  {
    // Arrange
    var startsAtUtc = LocalDate.FromDateOnly(DateOnly.FromDateTime(DateTime.Now));

    // Act
    var meet = Meet.Create(
      Faker.Company.CompanyName(),
      Faker.Address.City(),
      Faker.Company.CompanyName(),
      startsAtUtc,
      startsAtUtc.PlusDays(-1));

    // Assert
    meet.Error.Should().Be(MeetErrors.EndDatePrecedesStartDate);
  }

  /// <summary>
  /// Asserts that a domain event is raised when a meet is created.
  /// </summary>
  [Fact]
  public void Create_ShouldRaiseDomainEvent_WnenMeetIsCreated()
  {
    // Arrange
    var startsAtUtc = LocalDate.FromDateOnly(DateOnly.FromDateTime(DateTime.Now));

    // Act
    var result = Meet.Create(
      Faker.Company.CompanyName(),
      Faker.Address.City(),
      Faker.Company.CompanyName(),
      startsAtUtc,
      startsAtUtc);

    var meet = result.Value;

    // Assert
    var domainEvent = AssertDomainEventWasPublished<MeetCreatedDomainEvent>(meet);
    domainEvent.MeetId.Should().Be(meet.Id);
  }
}
