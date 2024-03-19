namespace Modules.Users.Persistence.Constants;

/// <summary>
/// Represents the table names in the users module.
/// </summary>
internal static class TableNames
{
    /// <summary>
    /// The users table.
    /// </summary>
    internal const string _users = "users";

    /// <summary>
    /// The user roles table.
    /// </summary>
    internal const string _userRoles = "user_roles";

    /// <summary>
    /// The user registrations table.
    /// </summary>
    internal const string _userRegistrations = "user_registrations";

    /// <summary>
    /// The roles table.
    /// </summary>
    internal const string _roles = "roles";

    /// <summary>
    /// The roles table.
    /// </summary>
    internal const string _permissions = "permissions";

    /// <summary>
    /// The role permissions table.
    /// </summary>
    internal const string _rolePermissions = "role_permissions";

    /// <summary>
    /// The inbox messages table.
    /// </summary>
    internal const string _inboxMessages = "inbox_messages";

    /// <summary>
    /// The inbox message consumers table.
    /// </summary>
    internal const string _inboxMessageConsumers = "inbox_message_consumers";

    /// <summary>
    /// The outbox messages table.
    /// </summary>
    internal const string _outboxMessages = "outbox_messages";

    /// <summary>
    /// The outbox message consumers table.
    /// </summary>
    internal const string _outboxMessageConsumers = "outbox_message_consumers";
}