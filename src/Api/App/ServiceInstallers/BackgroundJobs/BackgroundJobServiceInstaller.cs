namespace App.ServiceInstallers.BackgroundJobs;

/// <summary>
/// Represents the background job service installer.
/// </summary>
internal sealed class BackgroundJobServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureOptions<RecurringJobSetup>()
            .ConfigureOptions<QuartzHostedServiceOptionsSetup>()
            .AddQuartz()
            .AddQuartzHostedService();
    }
}
