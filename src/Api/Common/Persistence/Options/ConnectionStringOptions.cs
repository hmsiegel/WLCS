namespace Persistence.Options;

/// <summary>
/// Represents the connection string.
/// </summary>
public sealed class ConnectionStringOptions
{
    /// <summary>
    /// Gets the connection string value.
    /// </summary>
    public string Value { get; internal set; } = string.Empty;

    /// <summary>
    /// Converts the connection string to a string.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    public static implicit operator string(ConnectionStringOptions connectionString)
    {
        if (connectionString is null)
        {
            ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));
        }

        return connectionString.Value;
    }
}