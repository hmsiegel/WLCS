namespace Domain.UserAggregate.ValueObjects;
public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;
    public string Value { get; }
    private FirstName(string value)
    {
        Value = value;
    }
    public static Result<FirstName> Create(string firstName) =>
        Result.Create(firstName)
            .Ensure(
                firstName => !string.IsNullOrWhiteSpace(firstName),
                DomainErrors.FirstName.Empty)
            .Ensure(
            firstName => firstName.Length <= MaxLength,
            DomainErrors.FirstName.Length)
            .Map(firstName => new FirstName(firstName));

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
