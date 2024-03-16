namespace App.Extensions;

/// <summary>
/// Contains extension methods for the <see cref="IHostBuilder"/> interface.
/// </summary>
internal static class HostBuilderExtensions
{
    /// <summary>
    /// Configures Serilog as a logging provider using the configuration defined in the application settings.
    /// </summary>
    /// <param name="hostBuilder">The host builder.</param>
    internal static void UseSerilogWihtConfiguration(this IHostBuilder hostBuilder) =>
        hostBuilder.UseSerilog((hostBuilderContext, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration));
}
