namespace Infrastructure.BackgroundJobs;

/// <summary>
/// Represents the interface for defining a recurring background job configuration.
/// </summary>
public interface IRecurringJobConfiguration
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the type.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Gets the interval in seconds.
    /// </summary>
    public int IntervalInSeconds { get; }
}