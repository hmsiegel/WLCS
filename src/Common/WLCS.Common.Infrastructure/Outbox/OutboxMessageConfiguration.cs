// <copyright file="OutboxMessageConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Outbox;

public sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
  public void Configure(EntityTypeBuilder<OutboxMessage> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ToTable("outbox_messages");

    builder.HasKey(outboxMessage => outboxMessage.Id);

    builder.Property(o => o.Content)
      .HasMaxLength(2000)
      .HasColumnType("jsonb");
  }
}
