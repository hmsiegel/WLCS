namespace Modules.Users.Persistence.Configurations;

/// <summary>
/// Represents the <see cref="OutboxMessageConsumer"/> entity configuration.
/// </summary>
internal sealed class OutboxMessageConsumerConfiguration : IEntityTypeConfiguration<OutboxMessageConsumer>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<OutboxMessageConsumer> builder) => ConfigureDataStructure(builder);

    private static void ConfigureDataStructure(EntityTypeBuilder<OutboxMessageConsumer> builder)
    {
        builder.ToTable(TableNames._outboxMessageConsumers);

        builder.HasKey(outboxMessageConsumer => new { outboxMessageConsumer.Id, outboxMessageConsumer.Name });
    }
}
