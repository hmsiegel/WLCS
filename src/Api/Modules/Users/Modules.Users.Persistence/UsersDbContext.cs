namespace Modules.Users.Persistence;

/// <summary>
/// Represents the users database context.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UsersDbContext"/> class.
/// </remarks>
/// <param name="options">The database context options.</param>
public sealed class UsersDbContext(DbContextOptions options) : DbContext(options)
{
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            ArgumentNullException.ThrowIfNull(nameof(modelBuilder));
        }

        modelBuilder!.HasDefaultSchema(Schemas.Users);

        modelBuilder!.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ConfigureSmartEnum();
        base.ConfigureConventions(configurationBuilder);
    }
}
