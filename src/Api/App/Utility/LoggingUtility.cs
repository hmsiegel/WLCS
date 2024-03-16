namespace App.Utility;

/// <summary>
/// Contains utility methods for logging.
/// </summary>
internal static class LoggingUtility
{
    /// <summary>
    /// Wraps the provided startup action with a try-catch-finally block and provides logging.
    /// </summary>
    /// <param name="startupAction">The startup action.</param>
    internal static void Run(Action startupAction)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(
            LogEventLevel.Information,
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
            CultureInfo.InvariantCulture)
            .CreateBootstrapLogger();

        Log.Information("Starting up.");

        FunctionalExtensions.TryCatchFinally(
            startupAction,
            exception => Log.Fatal(exception, "Unhanled exception."),
            () =>
            {
                Log.Information("Shutting down.");
                Log.CloseAndFlush();
            });
    }
}
