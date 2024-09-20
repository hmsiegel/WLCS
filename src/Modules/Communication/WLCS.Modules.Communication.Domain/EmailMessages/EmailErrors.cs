// <copyright file="EmailErrors.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using WLCS.Common.Domain;

namespace WLCS.Modules.Communication.Domain.EmailMessages;

public static class EmailErrors
{
  public static Error NotFound => Error.NotFound(
    "Email.NotFound",
    "No emails were found in the Outbox.");
}
