namespace Domain.UserAggregate.ValueObjects;
public sealed class Email : ValueObject
{
    public const int MaxLength = 255;

    public string? Value { get; }

    private Email(string? value)
    {
        Value = value;
    }

    public static Result<Email> Create(string? email) =>
        Result.Ensure(
            email,
            (e => !string.IsNullOrWhiteSpace(e), DomainErrors.Email.Empty),
            (e => e!.Length <= MaxLength, DomainErrors.Email.TooLong),
            (e => e!.Split('@').Length == 2, DomainErrors.Email.Invalid))
        .Map(e => new Email(e));

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value!;
    }
}
