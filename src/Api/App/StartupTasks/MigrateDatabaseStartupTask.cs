namespace App.StartupTasks;

/// <summary>
/// Represents the startup task for migrating the database in development environment only.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MigrateDatabaseStartupTask"/> class.
/// </remarks>
/// <param name="environment">The environment.</param>
/// <param name="serviceProvider">The service provider.</param>
internal sealed class MigrateDatabaseStartupTask(IHostEnvironment environment, IServiceProvider serviceProvider) : BackgroundService
{
    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!environment.IsDevelopment())
        {
            return;
        }

        using IServiceScope scope = serviceProvider.CreateScope();

        await MigrateDatabaseAsync<UsersDbContext>(scope, stoppingToken).ConfigureAwait(false);
    }

    private static async Task MigrateDatabaseAsync<T>(IServiceScope scope, CancellationToken cancellationToken)
        where T : DbContext
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();

        await dbContext.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
    }
}
