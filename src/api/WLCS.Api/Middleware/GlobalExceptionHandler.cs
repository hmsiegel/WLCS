// <copyright file="GlobalExceptionHandler.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace WLCS.Api.Middleware;

/// <summary>
/// Adds a global exception handler to the application.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
/// </remarks>
internal sealed class GlobalExceptionHandler
  : IExceptionHandler
{
  /// <inheritdoc/>
  public async ValueTask<bool> TryHandleAsync(
    HttpContext httpContext,
    Exception exception,
    CancellationToken cancellationToken)
  {
    LoggerMessage.Define(
      LogLevel.Error,
      new EventId(0, "UnhandledException"),
      "An unhandled exception has occurred.");

    var problemDetails = new ProblemDetails
    {
      Status = StatusCodes.Status500InternalServerError,
      Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
      Title = "Server failure",
    };

    httpContext.Response.StatusCode = problemDetails.Status.Value;

    await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken)
      .ConfigureAwait(false);

    return true;
  }
}
