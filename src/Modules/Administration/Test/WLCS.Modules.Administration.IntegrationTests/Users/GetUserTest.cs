﻿// <copyright file="GetUserTest.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Users;

public class GetUserTest(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Should_ReturnError_WhenUserDoesNotExistAsync()
  {
    // Arrange
    var userId = Guid.NewGuid();

    // Act
    var userResult = await Sender.Send(new GetUserQuery(userId));

    // Assert
    userResult.Errors[0].Should().Be(UserErrors.NotFoud(userId));
  }

  [Fact]
  public async Task Should_ReturnUser_WhenUserExistsAsync()
  {
    // Arrange
    var result = await Sender.Send(new RegisterUserCommand(
      Faker.Internet.Email(),
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName()));

    var userId = result.Value;

    // Act
    var userResult = await Sender.Send(new GetUserQuery(userId));

    // Assert
    userResult.IsSuccess.Should().BeTrue();
    userResult.Value.Should().NotBeNull();
  }
}
