// <copyright file="GetUserTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Users;

/// <summary>
/// Tests for the GetUser method.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetUserTests"/> class.
/// </remarks>
/// <param name="factory">An instance of the <see cref="IntegrationTestWebAppFactory"/>.</param>
public class GetUserTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  /// <summary>
  /// Asserts  that the GetUserQuery should return an error when the user does not exist.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnError_WhenUserDoesNotExistAsync()
  {
    // Arrange
    var userId = Guid.NewGuid();

    // Act
    var result = await Sender.Send(new GetUserQuery(userId));

    // Assert
    result.Error.Should().Be(UserErrors.NotFound(userId));
  }

  /// <summary>
  /// Asserts that the GetUserQuery should return the user when the user exists.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
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

    // Act
    var userResult = await Sender.Send(new GetUserQuery(userId));

    // Assert
    userResult.IsSuccess.Should().BeTrue();
    userResult.Value.Should().NotBeNull();
  }
}
