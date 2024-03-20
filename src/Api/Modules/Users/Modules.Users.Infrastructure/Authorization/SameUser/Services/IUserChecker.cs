namespace Modules.Users.Infrastructure.Authorization.SameUser.Services;

/// <summary>
/// Represents the user checker interface.
/// </summary>
public interface IUserChecker
{
    /// <summary>
    /// Checks if the user with pecified identifier and identity provider identifier exists.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="identityProviderId">The identity provider id.</param>
    /// <param name="cancellationToken">The cancallation token.</param>
    /// <returns>True if the user with the specified identifier and identity provider identifier exists, otherwise false.</returns>
    public Task<bool> ExistsAsync(DefaultIdType userId, string identityProviderId, CancellationToken cancellationToken = default);
}
