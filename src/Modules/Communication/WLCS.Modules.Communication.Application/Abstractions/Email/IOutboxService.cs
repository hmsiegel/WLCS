// <copyright file="IOutboxService.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Application.Abstractions.Email;

public interface IOutboxService
{
  Task QueueEmailForSending(EmailOutboxEntity entity);
}
