namespace Persistence.Interceptors;

/// <summary>
/// Represents the interceptor for updating entity values.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateAuditableEntitiesInterceptor"/> class.
/// </remarks>
/// <param name="systemTime">The system time.</param>
public sealed class UpdateAuditableEntitiesInterceptor(ISystemTime systemTime) : SaveChangesInterceptor
{
    /// <inheritdoc/>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        DateTime utcNow = systemTime.UtcNow;

        foreach (EntityEntry<IAuditable> auditable in GetAuditableEntities(eventData.Context))
        {
            if (auditable.State == EntityState.Added)
            {
                auditable.Property(nameof(IAuditable.CreatedOnUtc)).CurrentValue = utcNow;
            }

            if (auditable.State == EntityState.Modified)
            {
                auditable.Property(nameof(IAuditable.ModifiedOnUtc)).CurrentValue = utcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static IEnumerable<EntityEntry<IAuditable>> GetAuditableEntities(DbContext context) =>
        context.ChangeTracker
            .Entries<IAuditable>();
}
