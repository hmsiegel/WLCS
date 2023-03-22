namespace Api.Configurations.BuilderConfigurations;
public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Application.ApplicationAssembly.Assembly));
        services.AddValidatorsFromAssembly(Application.ApplicationAssembly.Assembly, includeInternalTypes: true);
    }
}
