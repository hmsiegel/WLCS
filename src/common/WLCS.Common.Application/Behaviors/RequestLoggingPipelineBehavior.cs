// <copyright file="RequestLoggingPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

/// <summary>
/// Adds logging to the request pipeline.
/// </summary>
/// <typeparam name="TRequest">The request.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
  /// <inheritdoc/>
  public async Task<TResponse> Handle(
      TRequest request,
      RequestHandlerDelegate<TResponse> next,
      CancellationToken cancellationToken)
  {
    string moduleName = GetModuleName(typeof(TRequest).FullName!);
    string requestName = typeof(TRequest).Name;

    using (LogContext.PushProperty("Module", moduleName))
    {
      LoggerMessage.Define<string>(
          LogLevel.Information,
          new EventId(1, "Request"),
          $"Processing request {requestName}");

      var result = await next().ConfigureAwait(false);

      if (result.IsSuccess)
      {
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(2, "Request"),
            $"Completed request {requestName}");
      }
      else
      {
        using (LogContext.PushProperty("Error", result, true))
        {
          LoggerMessage.Define<string>(
              LogLevel.Error,
              new EventId(3, "Request"),
              $"Completed request {requestName} with error");
        }
      }

      return result;
    }
  }

  private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}
