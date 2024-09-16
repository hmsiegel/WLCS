// <copyright file="GetUserTest.cs" company="WLCS">
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
    userResult.Errors[0].Should().Be(UserErrors.NotFound(userId));
  }

  [Fact]
  public async Task Should_ReturnUser_WhenUserExistsAsync()
  {
    // Arrange
    var command = new RegisterUserCommand(
      Faker.Internet.Email(),
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName());

    var result = await Sender.Send(command);

    var userId = result.Value;

    var query = new GetUserQuery(userId);

    // Act
    var userResult = await Sender.Send(query);

    // Assert
    userResult.IsSuccess.Should().BeTrue();
    userResult.Value.Should().NotBeNull();
  }
}
