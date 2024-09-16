// <copyright file="TestAuthHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.IntegrationTests.MockAuthentication;

public class TestAuthHandler(
  IOptionsMonitor<AuthenticationSchemeOptions> options,
  ILoggerFactory logger,
  UrlEncoder encoder,
  MockAuthUser user)
  : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
  private readonly MockAuthUser _user = user;

  protected override Task<AuthenticateResult> HandleAuthenticateAsync()
  {
    if (_user.Claims.Count == 0)
    {
      return Task.FromResult(AuthenticateResult.Fail("Mock authentication user is not configured."));
    }

    var identity = new ClaimsIdentity(_user.Claims, AuthConstants.Scheme);
    var principal = new ClaimsPrincipal(identity);
    var ticket = new AuthenticationTicket(principal, AuthConstants.Scheme);

    var result = AuthenticateResult.Success(ticket);
    return Task.FromResult(result);
  }
}
