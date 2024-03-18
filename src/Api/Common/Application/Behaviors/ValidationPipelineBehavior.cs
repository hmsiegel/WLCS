namespace Application.Behaviors;

/// <summary>
/// Represents the validation pipeline behavior.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
/// <summary>
/// Initializes a new instance of the <see cref="ValidationBehavior{TRequest,TResponse}"/> class.
/// </summary>
/// <param name="validator">The validators for the given request.</param>
public sealed class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest> validator)
    : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator = validator;

    /// <inheritdoc/>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next().ConfigureAwait(false);
        }

        var validationResult = await _validator.ValidateAsync(
            request,
            cancellationToken).ConfigureAwait(false);

        if (validationResult.IsValid)
        {
            return await next().ConfigureAwait(false);
        }

        var errors = validationResult.Errors
            .ConvertAll(error => Error.Validation(
                code: error.PropertyName,
                description: error.ErrorMessage));

        return (dynamic)errors;
    }
}