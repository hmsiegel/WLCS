// <copyright file="LogContextTraceLoggingMiddleware.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Gateway.Middleware;

internal sealed class LogContextTraceLoggingMiddleware(RequestDelegate next)
{
  private readonly RequestDelegate _next = next;

  public Task Invoke(HttpContext context)
  {
    var traceId = Activity.Current?.TraceId.ToString();

    using (LogContext.PushProperty("TraceId", traceId))
    {
      return _next.Invoke(context);
    }
  }
}
