// <copyright file="StaticLogger.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Logging;

public static class StaticLogger
{
  public static void EnsureInitialized()
  {
    if (Log.Logger is not Serilog.Core.Logger)
    {
      Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console(formatProvider: CultureInfo.CurrentCulture)
        .CreateLogger();
    }
  }
}
