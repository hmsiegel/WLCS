namespace App.ServiceInstallers.Swagger;

/// <summary>
/// Represents the swagger service installer.
/// </summary>
internal sealed class SwagggerServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureOptions<SwaggerGenOptionsSetup>();

        services.ConfigureOptions<SwaggerUiOptionsSetup>();

        services.AddEndpointsApiExplorer();

        services.AddControllers();

        services.AddSwaggerGen();
    }
}
