namespace Api.Configurations.BuilderConfigurations;
public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .Scan(
            scan => scan
               .FromAssemblies(
                    Infrastructure.InfrastructureAssembly.Assembly,
                    Persistence.PersistenceAssembly.Assembly)
              .AddClasses(false)
              .UsingRegistrationStrategy(RegistrationStrategy.Skip)
              .AsMatchingInterface()
              .WithScopedLifetime());

        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
}
