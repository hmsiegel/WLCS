namespace Persistence.Configurations;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);

        builder.HasKey(t => t.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(
                id  => id!.Value,
                value => new UserId(value));

        builder
            .Property(x => x.Email)
            .HasMaxLength(Email.MaxLength)
            .HasConversion(
            email => email!.Value,
            value => Email.Create(value).Value);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(FirstName.MaxLength)
            .HasConversion(
            firstName => firstName!.Value,
            value => FirstName.Create(value).Value);

         
        builder
            .Property(x => x.LastName )
            .HasMaxLength(LastName.MaxLength)
            .HasConversion(
            lastName => lastName!.Value,
            value => LastName.Create(value).Value);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
