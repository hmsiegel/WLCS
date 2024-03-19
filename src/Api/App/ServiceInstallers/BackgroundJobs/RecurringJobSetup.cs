namespace App.ServiceInstallers.BackgroundJobs;

/// <summary>
/// Represents the <see cref="QuartzOptions"/> setup.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RecurringJobSetup"/> class.
/// </remarks>
/// <param name="recurringJobConfigurations">The recurring job configuration.</param>
internal sealed class RecurringJobSetup(IEnumerable<IRecurringJobConfiguration> recurringJobConfigurations)
    : IConfigureOptions<QuartzOptions>
{
    /// <inheritdoc />
    public void Configure(QuartzOptions options)
    {
        recurringJobConfigurations.ForEach(config =>
            options
            .AddJob(
                config.Type,
                jobBuilder => jobBuilder.WithIdentity(config.Name))
            .AddTrigger(triggerBuilder =>
                triggerBuilder
                    .ForJob(config.Name)
                    .WithSimpleSchedule(scheduleBuilder =>
                        scheduleBuilder
                        .WithIntervalInSeconds(config.IntervalInSeconds)
                           .RepeatForever())));
    }
}
