// <copyright file="EmailOptions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Modules.Communication.Infrastructure.Email;

internal sealed class EmailOptions
{
  public string From { get; init; } = default!;

  public string Host { get; init; } = default!;

  public int Port { get; init; }

  public bool UseSsl { get; init; }
}
