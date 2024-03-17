namespace Application.Data;

/// <summary>
/// Represents the unit of work interface.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves the changes to the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation toke.</param>
    /// <returns>The return code.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
