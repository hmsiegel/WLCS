// <copyright file="UpdateUserTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>
namespace WLCS.Modules.Administration.IntegrationTests.Users;

public class UpdateUserTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  public static readonly TheoryData<UpdateUserCommand> InvalidCommands = new()
  {
    new UpdateUserCommand(Guid.Empty, Faker.Name.FirstName(), Faker.Name.LastName()),
    new UpdateUserCommand(Guid.NewGuid(), string.Empty, Faker.Name.LastName()),
    new UpdateUserCommand(Guid.NewGuid(), Faker.Name.FirstName(), string.Empty),
  };

  [Theory]
  [MemberData(nameof(InvalidCommands))]
  public async Task Should_ReturnError_WhenCommandIsNotValidAsync(UpdateUserCommand command)
  {
    // Act
    var response = await Sender.Send(command);

    // Assert
    response.IsFailure.Should().BeTrue();
    response.Errors[0].Type.Should().Be(ErrorType.Validation);
  }

  [Fact]
  public async Task Should_ReturnError_WhenUserDoesNotExistAsync()
  {
    // Arrange
    var userId = Guid.NewGuid();

    // Act
    var response = await Sender.Send(new UpdateUserCommand(userId, Faker.Name.FirstName(), Faker.Name.LastName()));

    // Assert
    response.Errors[0].Should().Be(UserErrors.NotFoud(userId));
  }

  [Fact]
  public async Task Should_ReturnSuccess_WhenUserExistsAsync()
  {
    // Arrange
    var result = await Sender.Send(new RegisterUserCommand(
      Faker.Internet.Email(),
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName()));

    var userId = result.Value;

    // Act
    var response = await Sender.Send(new UpdateUserCommand(userId, Faker.Name.FirstName(), Faker.Name.LastName()));

    // Assert
    response.IsSuccess.Should().BeTrue();
  }
}
