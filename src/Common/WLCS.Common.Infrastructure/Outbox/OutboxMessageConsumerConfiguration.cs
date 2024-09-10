// <copyright file="OutboxMessageConsumerConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Outbox;

public sealed class OutboxMessageConsumerConfiguration : IEntityTypeConfiguration<OutboxMessageConsumer>
{
  public void Configure(EntityTypeBuilder<OutboxMessageConsumer> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ToTable("outbox_message_consumers");

    builder.HasKey(x => new { x.OutboxMessageId, x.Name });

    builder.Property(x => x.Name)
      .HasMaxLength(500);
  }
}
