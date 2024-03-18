namespace Persistence.Data;

/// <summary>
/// Represents the SQL query executor.
/// </summary>
/// <param name="sqlConnectionFactory">The SQL connection factory.</param>
internal sealed class SqlQueryExecutor(ISqlConnectionFactory sqlConnectionFactory) : ISqlQueryExecutor, ITransient
{
    /// <inheritdoc/>
    public async Task ExecuteAsync(string sql, object? parameters = null) =>
        await sqlConnectionFactory.GetOpenConnection().ExecuteAsync(sql, parameters);

    /// <inheritdoc/>
    public async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null)
    {
        var sqlExecution = await sqlConnectionFactory.GetOpenConnection().ExecuteScalarAsync<T>(sql, parameters);
        return sqlExecution!;
    }

    /// <inheritdoc/>
    public Task<T?> FirstOrDefaultAsync<T>(string sql, object? parameters = null) =>
        sqlConnectionFactory.GetOpenConnection().QueryFirstOrDefaultAsync<T>(sql, parameters);

    /// <inheritdoc/>
    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null) =>
        await sqlConnectionFactory.GetOpenConnection().QueryAsync<T>(sql, parameters);

    /// <inheritdoc/>
    public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, TResult>(
        string sql,
        Func<T1, T2, TResult> map,
        object? parameters = null,
        string splitOn = "Id") =>
        await sqlConnectionFactory.GetOpenConnection().QueryAsync(sql, map, parameters, splitOn: splitOn);
}
