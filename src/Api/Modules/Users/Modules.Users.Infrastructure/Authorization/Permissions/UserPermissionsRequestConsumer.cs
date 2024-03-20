namespace Modules.Users.Infrastructure.Authorization.Permissions;

/// <summary>
/// Represents the <see cref="IUserPermissionsRequest"/> consumer.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserPermissionsRequestConsumer"/> class.
/// </remarks>
/// <param name="sqlQueryExecutor">The SQL query executor.</param>
internal sealed class UserPermissionsRequestConsumer(ISqlQueryExecutor sqlQueryExecutor) : IConsumer<IUserPermissionsRequest>
{
    /// <inheritdoc />
    public async Task Consume(ConsumeContext<IUserPermissionsRequest> context)
    {
        const string sql = @"
            SELECT DISTINCT p.name
            FROM users.users u
            JOIN users.user_roles ur ON u.id = ur.user_id
            JOIN users.roles r ON r.id = ur.role_id
            JOIN users.role_permissions rp ON r.id = rp.role_id
            JOIN users.permissions p ON p.id = rp.permission_id
            WHERE u.identity_provider_id = @UserIdentityProviderId";

        IEnumerable<string> permissions = await sqlQueryExecutor.QueryAsync<string>(sql, context.Message).ConfigureAwait(false);

        var response = new UserPermissionsResponse
        {
            Permissions = permissions.ToHashSet(),
        };

        await context.RespondAsync<IUserPermissionsResponse>(response).ConfigureAwait(false);
    }

    private sealed class UserPermissionsResponse : IUserPermissionsResponse
    {
        public HashSet<string> Permissions { get; init; } = [];
    }
}
