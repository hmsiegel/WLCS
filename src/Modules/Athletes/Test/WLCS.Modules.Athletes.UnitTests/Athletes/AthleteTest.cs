// <copyright file="AthleteTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Athletes.UnitTests.Athletes;

public class AthleteTest : BaseTest
{
  [Fact]
  public void Create_ShouldRaiseDomainEvent_WhenAthleteIsCreated()
  {
    // Arrange
    var membershipResult = Membership.Create(Faker.GlobalUniqueIndex.ToString(CultureInfo.InvariantCulture));
    var firstNameResult = FirstName.Create(Faker.Name.FirstName());
    var lastNameResult = LastName.Create(Faker.Name.LastName());
    var dateOfBirth = Faker.Date.PastDateOnly(Faker.Random.Number(1, 99));
    var emailResult = Email.Create(Faker.Internet.Email());
    var genderResult = Gender.FromValue(Faker.Random.Number(0, 1));

    // Act
    var results = Athlete.Create(
      membership: membershipResult.Value,
      firstName: firstNameResult.Value,
      lastName: lastNameResult.Value,
      dateOfBirth: dateOfBirth,
      email: emailResult.Value,
      genderResult);

    // Assert
    var domainEvent = AssertDomainEventWasPublished<AthleteRegisteredDomainEvent>(results);

    domainEvent.AthleteId.Should().Be(results.Id.Value);
  }
}
