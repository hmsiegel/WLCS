namespace Domain.UserAggregate.ValueObjects;
public sealed class LastName : ValueObject
{
    public const int MaxLength = 50;
    public string Value { get; }

    private LastName(string value)
    {
        Value = value;
    }

    public static Result<LastName> Create(string lastName) =>
        Result.Create(lastName)
            .Ensure(
                lastName => !string.IsNullOrWhiteSpace(lastName),
                DomainErrors.LastName.Empty)
            .Ensure(
            lastName => lastName.Length <= MaxLength,
            DomainErrors.LastName.Length)
            .Map(lastName => new LastName(lastName));

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
