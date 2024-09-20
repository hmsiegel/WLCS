// <copyright file="ISendEmailsFromOutboxService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal interface ISendEmailsFromOutboxService
{
  Task CheckForAndSendEmails();
}
