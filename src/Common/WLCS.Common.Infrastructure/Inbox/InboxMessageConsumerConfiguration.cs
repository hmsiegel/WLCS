// <copyright file="InboxMessageConsumerConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Inbox;

public sealed class InboxMessageConsumerConfiguration : IEntityTypeConfiguration<InboxMessageConsumer>
{
  public void Configure(EntityTypeBuilder<InboxMessageConsumer> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ToTable("inbox_message_consumers");

    builder.HasKey(x => new { x.InboxMessageId, x.Name });

    builder.Property(x => x.Name)
      .HasMaxLength(500);
  }
}
