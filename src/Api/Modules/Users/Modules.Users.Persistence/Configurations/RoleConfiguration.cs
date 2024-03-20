namespace Modules.Users.Persistence.Configurations;

/// <summary>
/// Represents the <see cref="Role"/> entity configuration.
/// </summary>
internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Role> builder) =>
        builder
            .Tap(ConfigureDataStructure);

    private static void ConfigureDataStructure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames._roles);

        builder.HasKey(role => role.Id);

        builder.Property(role => role.Id).ValueGeneratedNever();

        builder.Property(role => role.Name).HasMaxLength(100);

        builder.HasData(Role.GetValues());
    }
}
