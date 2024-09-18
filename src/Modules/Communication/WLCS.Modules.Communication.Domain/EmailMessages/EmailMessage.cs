// <copyright file="EmailMessage.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Domain.EmailMessages;

public sealed class EmailMessage
{
  public string To { get; set; } = string.Empty;

  public string From { get; set; } = string.Empty;

  public string Subject { get; set; } = string.Empty;

  public string Body { get; set; } = string.Empty;

  public string? Cc { get; set; } = string.Empty;

  public string? Bcc { get; set; } = string.Empty;

  public string? ReplyTo { get; set; } = string.Empty;
}
