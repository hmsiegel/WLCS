namespace Modules.Users.Persistence.Configurations;

/// <summary>
/// Represents the <see cref="InboxMessageConsumer"/> entity configuration.
/// </summary>
internal sealed class InboxMessageConsumerConfiguration : IEntityTypeConfiguration<InboxMessageConsumer>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<InboxMessageConsumer> builder) => ConfigureDataStructure(builder);

    private static void ConfigureDataStructure(EntityTypeBuilder<InboxMessageConsumer> builder)
    {
        builder.ToTable(TableNames._inboxMessageConsumers);

        builder.HasKey(inboxMessageConsumer => new { inboxMessageConsumer.Id, inboxMessageConsumer.Name });
    }
}
