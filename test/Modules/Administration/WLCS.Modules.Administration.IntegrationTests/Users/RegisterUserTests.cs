// <copyright file="RegisterUserTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Administration.IntegrationTests.Users;

/// <summary>
/// Test class for the RegisterUser method.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RegisterUserTests"/> class.
/// </remarks>
/// <param name="factory">An instance of the <see cref="IntegrationTestWebAppFactory"/>.</param>
public class RegisterUserTests(IntegrationTestWebAppFactory factory)
  : BaseIntegrationTest(factory)
{
  /// <summary>
  /// Registers invalid test data.
  /// </summary>
  public static readonly TheoryData<string, string, string, string> InvalidRequests = new()
  {
    { string.Empty, Faker.Internet.Password(), Faker.Name.FirstName(), Faker.Name.LastName() },
    { Faker.Internet.Email(), string.Empty, Faker.Name.FirstName(), Faker.Name.LastName() },
    { Faker.Internet.Email(), "12345", Faker.Name.FirstName(), Faker.Name.LastName() },
    { Faker.Internet.Email(), Faker.Internet.Password(), string.Empty, Faker.Name.LastName() },
    { Faker.Internet.Email(), Faker.Internet.Password(), Faker.Name.FirstName(), string.Empty },
  };

  /// <summary>
  /// Asserts that the RegisterUser method returns a 400 Bad Request status code when the request is invalid.
  /// </summary>
  /// <param name="email">The email address.</param>
  /// <param name="password">The password.</param>
  /// <param name="firstName">The first name.</param>
  /// <param name="lastName">The last name.</param>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Theory]
  [MemberData(nameof(InvalidRequests))]
  public async Task Should_ReturnBadRequest_WhenRequestIsInvalidAsync(string email, string password, string firstName, string lastName)
  {
    // Arrange
    var request = new RegisterUser.Request(
      email,
      password,
      firstName,
      lastName);

    // Act
    var response = await HttpClient.PostAsJsonAsync("users/register", request);

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
  }

  /// <summary>
  /// Asserts that the RegisterUser method returns a 200 OK status code when the request is valid.
  /// </summary>
  /// <returns>An asynchronous task.</returns>
  [Fact]
  public async Task Should_ReturnOk_WhenRequestIsValidAsync()
  {
    // Arrange
    var request = new RegisterUser.Request(
      "create@test.com",
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName());

    // Act
    var response = await HttpClient.PostAsJsonAsync("users/register", request);

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.OK);
  }

  /// <summary>
  /// Asserts that the RegisterUser method returns an access token when the user is registered.
  /// </summary>
  /// <returns>An asynchronous task.</returns>
  [Fact]
  public async Task Should_ReturnAccessToken_WhenUserIsRegisteredAsync()
  {
    // Arrange
    var request = new RegisterUser.Request(
      "create@test.com",
      Faker.Internet.Password(),
      Faker.Name.FirstName(),
      Faker.Name.LastName());

    await HttpClient.PostAsJsonAsync("users/register", request);

    // Act
    var accessToken = await GetAccessTokenAsync(request.Email, request.Password);

    // Assert
    accessToken.Should().NotBeEmpty();
  }
}
