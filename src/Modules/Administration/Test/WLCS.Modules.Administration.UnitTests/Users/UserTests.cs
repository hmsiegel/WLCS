// <copyright file="UserTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using FluentAssertions;

namespace WLCS.Modules.Administration.UnitTests.Users;

public class UserTests : BaseTest
{
  [Fact]
  public void RegisterUser_ShouldRaiseDomainEvent_WhenUserIsRegistered()
  {
    // Arrange
    var email = Email.Create(Faker.Internet.Email());
    var firstName = FirstName.Create(Faker.Name.FirstName());
    var lastName = LastName.Create(Faker.Name.LastName());
    var identityId = Faker.Random.Guid().ToString();

    // Act
    var user = User.Create(
      email.Value,
      firstName.Value,
      lastName.Value,
      identityId);

    var domainEvent = AssertDomainEventWasPublished<UserRegisteredDomainEvent>(user);

    // Assert
    domainEvent.UserId.Should().Be(user.Id.Value);
  }
}
