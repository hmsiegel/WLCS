namespace Persistence.Extensions;

/// <summary>
/// Contains extension methods to <see cref="NpgsqlDbContextOptionsBuilder"/>.
/// </summary>
public static class NpgsqlDbContextOptionsBuilderExtensions
{
    /// <summary>
    /// Configures the migration history table to live in the specified schema.
    /// </summary>
    /// <param name="builder">The database context options builder.</param>
    /// <param name="schema">The schema.</param>
    /// <returns>The same database context options builder.</returns>
    public static NpgsqlDbContextOptionsBuilder WithMigrationHistoryTableInSchema(
        this NpgsqlDbContextOptionsBuilder builder,
        string schema)
    {
        if (builder is null)
        {
            ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        }

        return builder.MigrationsHistoryTable(TableNames._migrationHistory, schema);
    }
}
