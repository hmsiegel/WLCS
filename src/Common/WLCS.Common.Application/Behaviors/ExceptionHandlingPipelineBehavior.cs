// <copyright file="ExceptionHandlingPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
  ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : class
{
  private readonly ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> _logger = logger;

  public async Task<TResponse> Handle(
    TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken)
  {
    try
    {
      return await next();
    }
    catch (Exception exception)
    {
      _logger.LogException(typeof(TRequest).Name, exception);
      throw new WlcsException(typeof(TRequest).Name, innerException: exception);
    }
  }
}
