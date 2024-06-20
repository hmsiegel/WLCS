// <copyright file="ValidationPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

/// <summary>
/// Validation pipeline behavior.
/// </summary>
/// <typeparam name="TRequest">The request.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ValidationPipelineBehavior{TRequest, TResponse}"/> class.
/// </remarks>
/// <param name="validators">The validators.</param>
internal sealed class ValidationPipelineBehavior<TRequest, TResponse>(
   IEnumerable<IValidator<TRequest>> validators)
  : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
  private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

  /// <inheritdoc/>
  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    if (_validators.Any())
    {
      var context = new ValidationContext<TRequest>(request);

      var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);
      var resultErrors = validationResults.SelectMany(r => r.AsErrors()).ToList();
      var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

      if (failures.Count != 0)
      {
        if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
        {
          var resultType = typeof(TResponse).GetGenericArguments()[0];
          var invalidMethod = typeof(Result<>)
              .MakeGenericType(resultType)
              .GetMethod(nameof(Result<int>.Invalid), [typeof(List<ValidationError>)]);

          if (invalidMethod != null)
          {
            return (TResponse)invalidMethod.Invoke(null, [resultErrors])!;
          }
        }
        else if (typeof(TResponse) == typeof(Result))
        {
          return (TResponse)(object)Result.Invalid(resultErrors);
        }
        else
        {
          throw new ValidationException(failures);
        }
      }
    }

    return await next().ConfigureAwait(false);
  }
}
