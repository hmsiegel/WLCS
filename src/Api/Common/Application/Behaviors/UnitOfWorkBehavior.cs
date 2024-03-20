namespace Application.Behaviors;

/// <summary>
/// Represents a behavior that ensures that the changes are saved to the database.
/// </summary>
/// <typeparam name="TRequest">The request.</typeparam>
/// <typeparam name="TResponse">The response.</typeparam>
/// <param name="unitOfWork">A unit of work object.</param>
public sealed class UnitOfWorkBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    /// <inheritdoc/>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!IsCommand())
        {
            return await next().ConfigureAwait(false);
        }

        var response = await next().ConfigureAwait(false);

        await unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return response;
    }

    /// <summary>
    /// Checks if the request is a command.
    /// </summary>
    /// <returns>Returns true if it is a command.</returns>
    private static bool IsCommand()
    {
        return typeof(TRequest).Name.EndsWith("Command", StringComparison.InvariantCulture);
    }
}
