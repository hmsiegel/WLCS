// <copyright file="UpdateUserTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Users;

/// <summary>
/// Tests for the UpdateUser method.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateUserTests"/> class.
/// </remarks>
/// <param name="factory">An instance of the <see cref="IntegrationTestWebAppFactory"/>.</param>
public class UpdateUserTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  /// <summary>
  /// The invalid test data.
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "Reviewed")]
  public static readonly TheoryData<UpdateUserCommand> InvalidCommands = new()
  {
    new UpdateUserCommand(Guid.Empty,  Faker.Name.FirstName(), Faker.Name.LastName()),
    new UpdateUserCommand(Guid.NewGuid(),  string.Empty, Faker.Name.LastName()),
    new UpdateUserCommand(Guid.NewGuid(),  Faker.Name.FirstName(), string.Empty),
  };

  /// <summary>
  /// Asserts that the UpdateUser method should return an error when the command is not valid.
  /// </summary>
  /// <param name="command">The <see cref="UpdateUserCommand"/>.</param>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Theory]
  [MemberData(nameof(InvalidCommands))]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1044:Avoid using TheoryData type arguments that are not serializable", Justification = "Reviewed")]
  public async Task Should_ReturnError_WhenCommandIsNotValidAsync(UpdateUserCommand command)
  {
    // Act
    var result = await Sender.Send(command);

    // Assert
    result.IsFailure.Should().BeTrue();
    result.Error.Type.Should().Be(ErrorType.Validation);
  }

  /// <summary>
  /// Asserts  that the UpdateUserCommand should return an error when the user does not exist.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnError_WhenUserDoesNotExistAsync()
  {
    // Arrange
    var userId = Guid.NewGuid();

    // Act
    var result = await Sender.Send(new UpdateUserCommand(
      userId,
      Faker.Name.FirstName(),
      Faker.Name.LastName()));

    // Assert
    result.Error.Should().Be(UserErrors.NotFound(userId));
  }

  /// <summary>
  /// Asserts that the UpdateUserCommand should return success when the user exists.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task Should_ReturnSuccess_WhenUserExistsAsync()
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
    var userResult = await Sender.Send(new UpdateUserCommand(
      userId,
      Faker.Name.FirstName(),
      Faker.Name.LastName()));

    // Assert
    userResult.IsSuccess.Should().BeTrue();
  }
}
