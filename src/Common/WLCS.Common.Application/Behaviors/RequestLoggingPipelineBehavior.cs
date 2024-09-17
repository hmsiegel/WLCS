// <copyright file="RequestLoggingPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
  ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger,
  IDateTimeProvider dateTimeProvider)
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : class
  where TResponse : Result
{
  private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger = logger;
  private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

  public async Task<TResponse> Handle(
    TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken)
  {
    var moduleName = GetModuleName(typeof(TRequest).FullName!);
    var requestName = typeof(TRequest).Name!;

    Activity.Current?.SetTag("request.module", moduleName);
    Activity.Current?.SetTag("request.name", requestName);

    using (LogContext.PushProperty("Module", moduleName))
    {
      _logger.ProcessingRequest(requestName, _dateTimeProvider.UtcNow);

      var result = await next();

      if (result.IsSuccess)
      {
        _logger.CompletedRequest(requestName, _dateTimeProvider.UtcNow);
      }
      else
      {
        using (LogContext.PushProperty("Error", result.Errors.FirstOrDefault(), true))
        {
          _logger.RequestErrors(requestName, result.Errors.FirstOrDefault()!);
        }
      }

      return result;
    }
  }

  private static string GetModuleName(string requestName) => requestName.Split('.')[2];
}
