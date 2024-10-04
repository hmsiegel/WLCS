// <copyright file="LoggingExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Logging;

public static class LoggingExtensions
{
  public static void RegisterSerilog(this WebApplicationBuilder builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
      loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    });
  }
}
