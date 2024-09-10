// <copyright file="InboxMessageConfiguration.cs" company="WLCS">
// Copyright (c) WLCS. All rights reserved.
// </copyright>

namespace WLCS.Common.Infrastructure.Inbox;

public sealed class InboxMessageConfiguration : IEntityTypeConfiguration<InboxMessage>
{
  public void Configure(EntityTypeBuilder<InboxMessage> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ToTable("inbox_messages");

    builder.HasKey(inboxMessage => inboxMessage.Id);

    builder.Property(o => o.Content)
      .HasMaxLength(2000)
      .HasColumnType("jsonb");
  }
}
