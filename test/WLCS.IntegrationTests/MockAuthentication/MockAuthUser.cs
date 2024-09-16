// <copyright file="MockAuthUser.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.MockAuthentication;

public class MockAuthUser(params Claim[] claims)
{
  public IReadOnlyCollection<Claim> Claims { get; private set; } = [.. claims];
}
