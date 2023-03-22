namespace Api.Configurations.WebApplicationConfiguration;

internal interface IWebApplicationConfiguration : IWebConfiguration
{
    void RegisterPipelineComponents(WebApplication app);
}