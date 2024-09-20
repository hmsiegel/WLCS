// <copyright file="DocumentDbSettings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal static class DocumentDbSettings
{
  internal const string Database = "email";

  internal const string EmailOutboxCollection = "emailOutbox";
}
