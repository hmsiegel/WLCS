namespace Persistence.Data;

/// <summary>
/// Represents the SQL connection factory.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SqlConnectionFactory"/> class.
/// </remarks>
/// <param name="connectionString">The connection string.</param>
internal sealed class SqlConnectionFactory(IOptions<ConnectionStringOptions> connectionString) : ISqlConnectionFactory, IDisposable, ITransient
{
    private readonly ConnectionStringOptions _connectionString = connectionString.Value;
    private IDbConnection? _connection;

    /// <inheritdoc/>
    public void Dispose()
    {
        _connection?.Dispose();
    }

    /// <inheritdoc/>
    public IDbConnection GetOpenConnection()
    {
        if ((_connection ??= new NpgsqlConnection(_connectionString)).State != ConnectionState.Open)
        {
            _connection.Open();
        }

        return _connection;
    }
}
