// <copyright file="RequestLoggingPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

/// <summary>
/// Adds logging to the request pipeline.
/// </summary>
/// <typeparam name="TRequest">The request.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="RequestLoggingPipelineBehavior{TRequest, TResponse}"/> class.
/// </remarks>
/// <param name="logger">An instance of ILogger.</param>
internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
  ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
  private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger = logger;

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
#pragma warning disable CA1848 // Use the LoggerMessage delegates
      _logger.LogInformation("Processing request {RequestName}", requestName);
#pragma warning restore CA1848 // Use the LoggerMessage delegates

      var result = await next().ConfigureAwait(false);

      if (result.IsSuccess)
      {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
        _logger.LogInformation("Completed request {RequestName}", requestName);
#pragma warning restore CA1848 // Use the LoggerMessage delegates
      }
      else
      {
        using (LogContext.PushProperty("Error", result, true))
        {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
          _logger.LogError("Completed request {RequestName} with error", requestName);
#pragma warning restore CA1848 // Use the LoggerMessage delegates
        }
      }

      return result;
    }
  }

  private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}
