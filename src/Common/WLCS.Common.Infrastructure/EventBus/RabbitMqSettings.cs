// <copyright file="RabbitMqSettings.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.EventBus;

public sealed record RabbitMqSettings(string Host, string Username = "guest", string Password = "guest");
