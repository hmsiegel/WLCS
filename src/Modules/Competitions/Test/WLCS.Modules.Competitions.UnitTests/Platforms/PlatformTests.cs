// <copyright file="PlatformTests.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Competitions.UnitTests.Platforms;

public class PlatformTests : BaseTest
{
  [Fact]
  public void CreatePlatform_ShouldRaiseDomainEvent_WhenPlatformIsCreated()
  {
    // Arrange
    var name = PlatformName.Create(Faker.Lorem.Word());
    var meetId = MeetId.Create(Faker.Random.Guid());

    // Act
    var platform = Platform.Create(
      meetId,
      name.Value);

    var domainEvent = AssertDomainEventWasPublished<PlatformCreatedDomainEvent>(platform);

    // Assert
    domainEvent.MeetId.Should().Be(platform.MeetId.Value);
    domainEvent.PlatformId.Should().Be(platform.Id.Value);
  }
}
