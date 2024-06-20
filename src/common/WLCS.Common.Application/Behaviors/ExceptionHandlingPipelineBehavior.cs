// <copyright file="ExceptionHandlingPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

/// <summary>
/// Implements the exception handling pipeline behavior.
/// </summary>
/// <typeparam name="TRequest">The request.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ExceptionHandlingPipelineBehavior{TRequest, TResponse}"/> class.
/// </remarks>
/// <param name="logger">The logger.</param>
internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
  ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : class
{
  private readonly ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> _logger = logger;

  /// <inheritdoc/>
  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    try
    {
      return await next().ConfigureAwait(false);
    }
    catch (Exception exception)
    {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
      _logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);
#pragma warning restore CA1848 // Use the LoggerMessage delegates

      throw new WLCSException(typeof(TRequest).Name, innerException: exception);
    }
  }
}
