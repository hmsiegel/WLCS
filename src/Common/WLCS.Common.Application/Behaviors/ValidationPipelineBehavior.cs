// <copyright file="ValidationPipelineBehavior.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Application.Behaviors;

internal sealed class ValidationPipelineBehavior<TRequest, TResponse>(
  IEnumerable<IValidator<TRequest>> validators)
  : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
  private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

  public async Task<TResponse> Handle(
    TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken)
  {
    ValidationFailure[] validationFailures = await ValidateAsync(request);

    if (validationFailures.Length == 0)
    {
      return await next();
    }

    if (typeof(TResponse).IsGenericType &&
        typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
    {
      Type resultType = typeof(TResponse).GetGenericArguments()[0];

      var failureMethod = typeof(Result<>)
        .MakeGenericType(resultType)
        .GetMethod(nameof(Result<object>.ValidationFailure));

      if (failureMethod is not null)
      {
        return (TResponse)failureMethod.Invoke(null, [CreateValidationError(validationFailures)])!;
      }
    }
    else if (typeof(TResponse) == typeof(Result))
    {
      return (TResponse)(object)Result.Failure(CreateValidationError(validationFailures));
    }

    throw new ValidationException(validationFailures);
  }

  private static ValidationError CreateValidationError(ValidationFailure[] validationFailures)
    => new(validationFailures.Select(failure => Error.Problem(failure.ErrorCode, failure.ErrorMessage)).ToArray());

  private async Task<ValidationFailure[]> ValidateAsync(TRequest request)
  {
    if (!_validators.Any())
    {
      return [];
    }

    var context = new ValidationContext<TRequest>(request);

    var validationResults = await Task.WhenAll(
      _validators.Select(validator => validator.ValidateAsync(context)));

    var validationFailure = validationResults
      .Where(result => !result.IsValid)
      .SelectMany(result => result.Errors)
      .ToArray();

    return validationFailure;
  }
}
