namespace Modules.Users.Persistence;

/// <summary>
/// Represents the users module unit of work.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
/// </remarks>
/// <param name="dbContext">The database context.</param>
internal sealed class UnitOfWork(UsersDbContext dbContext) : IUnitOfWork, IScoped
{
    /// <inheritdoc/>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
}
