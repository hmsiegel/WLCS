namespace App.ServiceInstallers.Swagger;

/// <summary>
/// Represents the setup for the Swagger UI options.
/// </summary>
internal sealed class SwaggerUiOptionsSetup : IConfigureOptions<SwaggerUIOptions>
{
    /// <inheritdoc/>
    public void Configure(SwaggerUIOptions options) => options.DisplayRequestDuration();
}
