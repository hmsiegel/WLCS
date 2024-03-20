namespace Domain.Primitives;

/// <summary>
/// Represents an enumeration of objects with a unique numeric identifier and a name.
/// </summary>
/// <typeparam name="TEnum">The type of the enumeration.</typeparam>
public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Lazy<Dictionary<int, TEnum>> _enumerationsDictionary = new (() => CreateEnumerationDictionary(typeof(TEnum)));

    /// <summary>
    /// Initializes a new instance of the <see cref="Enumeration{TEnum}"/> class.
    /// </summary>
    /// <param name="id">The enumeration identifier.</param>
    /// <param name="name">The enumeration name.</param>
    protected Enumeration(int id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Enumeration{TEnum}"/> class.
    /// </summary>
    /// <remarks>
    /// Required for deserialization.
    /// </remarks>
    protected Enumeration() => Name = string.Empty;

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; protected init; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; protected init; }

    /// <summary>
    ///  The equals operator.
    /// </summary>
    /// <param name="a">The first.</param>
    /// <param name="b">The second.</param>
    /// <returns>True if equals, false if not.</returns>
    public static bool operator ==(Enumeration<TEnum>? a, Enumeration<TEnum>? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    /// <summary>
    ///  The not equals operator.
    /// </summary>
    /// <param name="a">The first.</param>
    /// <param name="b">The second.</param>
    /// <returns>True if not equals, false if not.</returns>
    public static bool operator !=(Enumeration<TEnum> a, Enumeration<TEnum> b) => !(a == b);

    /// <summary>
    /// Gets the enumeration values.
    /// </summary>
    /// <returns>The read-only collection of enumeration values.</returns>
    public static IReadOnlyCollection<TEnum> GetValues() => [.. _enumerationsDictionary.Value.Values];

    /// <summary>
    /// Creates an enumeration of the specified type based on the specified identifier.
    /// </summary>
    /// <param name="id">The enumeration identifier.</param>
    /// <returns>The enumeration instance that matches the specified identifier, if it exists.</returns>
    public static TEnum? FromId(int id) => _enumerationsDictionary.Value.TryGetValue(id, out TEnum? enumeration) ? enumeration : null;

    /// <summary>
    /// Creates an enumeration of the specified type based on the specified name.
    /// </summary>
    /// <param name="name">The enumeration name.</param>
    /// <returns>The enumeration instance that matches the specified name, if it exists.</returns>
    public static TEnum? FromName(string name) => _enumerationsDictionary.Value.Values.SingleOrDefault(x => x.Name == name);

    /// <summary>
    /// Checks if the enumeration with the specified identifier exists.
    /// </summary>
    /// <param name="id">The enumeration identifier.</param>
    /// <returns>True if an enumeration with the specified identifier exists, otherwise false.</returns>
    public static bool Contains(int id) => _enumerationsDictionary.Value.ContainsKey(id);

    /// <inheritdoc />
    public virtual bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() && other.Id.Equals(Id);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        return obj is Enumeration<TEnum> otherValue && otherValue.Id.Equals(Id);
    }

    /// <inheritdoc />
    public override int GetHashCode() => Id.GetHashCode() * 37;

    private static Dictionary<int, TEnum> CreateEnumerationDictionary(Type enumType) => GetFieldsForType(enumType).ToDictionary(t => t.Id);

    private static IEnumerable<TEnum> GetFieldsForType(Type enumType) =>
        enumType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);
}
