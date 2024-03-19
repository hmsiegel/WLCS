namespace App.ServiceInstallers.Swagger;

/// <summary>
/// Represents the authorize operation filter.
/// </summary>
internal sealed class AuthorizeOperationFilter : IOperationFilter
{
    private static readonly HttpStatusCode[] _responseStatusCodes =
    [
        HttpStatusCode.Unauthorized,
        HttpStatusCode.Forbidden,
    ];

    /// <inheritdoc/>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var customAttributes = context.MethodInfo.GetCustomAttributes(true);

        var delcaringTypeCustomeAttributes = context.MethodInfo.DeclaringType!.GetCustomAttributes(true);

        bool isAuthorized = delcaringTypeCustomeAttributes.OfType<AuthorizeAttribute>().Any() ||
                            customAttributes.OfType<AuthorizeAttribute>().Any();

        bool isAnonymousAllowed = delcaringTypeCustomeAttributes.OfType<AllowAnonymousAttribute>().Any() ||
                                 customAttributes.OfType<AllowAnonymousAttribute>().Any();

        if (!isAuthorized || isAnonymousAllowed)
        {
            return;
        }

        foreach (var statusCode in _responseStatusCodes)
        {
            operation.Responses.TryAdd(
                ((int)statusCode).ToString(CultureInfo.InvariantCulture),
                new OpenApiResponse
                {
                    Description = statusCode.ToString(),
                });
        }
    }
}
