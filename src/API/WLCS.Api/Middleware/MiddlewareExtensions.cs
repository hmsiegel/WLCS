// <copyright file="MiddlewareExtensions.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Api.Middleware;

internal static class MiddlewareExtensions
{
  internal static IApplicationBuilder UseLogContextTraceLogging(this IApplicationBuilder app)
  {
    app.UseMiddleware<LogContextTraceLoggingMiddleware>();

    return app;
  }
}
