namespace Api.Configurations.WebApplicationConfiguration;
public static class RegisterExtensions
{
    public static void RegisterPipelineCompnents(this WebApplication app, Type scanningType)
    {
        var registrars = GetRegistrars<IWebApplicationConfiguration>(scanningType);

        foreach (var registrar in registrars)
        {
            registrar.RegisterPipelineComponents(app);
        }

    }

    private static IEnumerable<T> GetRegistrars<T>(Type scanningType)
        where T : IWebConfiguration =>
        scanningType.Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<T>();
}
