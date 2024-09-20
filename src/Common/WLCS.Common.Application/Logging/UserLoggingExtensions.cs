// <copyright file="UserLoggingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Logging;

public static class UserLoggingExtensions
{
  private static readonly Action<ILogger, string, Exception> _userRegistrationError = InitializeUserRegistrationError();
  private static readonly Action<ILogger, Exception> _userRoleError = InitializeUserRoleError();

  public static Action<ILogger, string, Exception> InitializeUserRegistrationError()
  {
    return LoggerMessage.Define<string>(
      LogLevel.Error,
      new EventId(6, nameof(UserRegistrationError)),
      "User registration failed for {RequestName}");
  }

  public static Action<ILogger, Exception> InitializeUserRoleError()
  {
    return LoggerMessage.Define(
      LogLevel.Error,
      new EventId(6, nameof(UserRoleError)),
      "An error occurred while adding a role to the user.");
  }

  public static void UserRegistrationError(this ILogger logger, string requestName, Exception exception)
    => _userRegistrationError(logger, requestName, exception);

  public static void UserRoleError(this ILogger logger, Exception exception)
    => _userRoleError(logger, exception);
}
