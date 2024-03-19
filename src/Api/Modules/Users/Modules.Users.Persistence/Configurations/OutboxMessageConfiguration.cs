namespace Modules.Users.Persistence.Configurations;

/// <summary>
/// Represents the <see cref="OutboxMessage"/> entity configuration.
/// </summary>
internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<OutboxMessage> builder) => ConfigureDataStructure(builder);

    private static void ConfigureDataStructure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable(TableNames._outboxMessages);

        builder.HasKey(outboxMessage => outboxMessage.Id);

        builder.Property(outboxMessage => outboxMessage.Id).ValueGeneratedNever();

        builder.Property(outboxMessage => outboxMessage.OccurredOnUtc).IsRequired();

        builder.Property(outboxMessage => outboxMessage.Type).IsRequired();

        builder.Property(outboxMessage => outboxMessage.Content).HasColumnType("json").IsRequired();

        builder.Property(outboxMessage => outboxMessage.ProcessedOnUtc).IsRequired(false);

        builder.Property(outboxMessage => outboxMessage.Error).IsRequired(false);
    }
}
