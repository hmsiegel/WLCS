namespace Modules.Users.Persistence.Configurations;

/// <summary>
/// Represents the <see cref="Permission"/> entity configuration.
/// </summary>
internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Permission> builder) =>
        builder
            .Tap(ConfigureDataStructure);

    private static void ConfigureDataStructure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(TableNames._permissions);

        builder.HasKey(permission => permission.Value);

        builder.Property(permission => permission.Value).ValueGeneratedNever();

        builder.Property(permission => permission.Name).HasMaxLength(100);

        builder.HasData(Permission.List.Select(permission => permission.Name));
    }
}
