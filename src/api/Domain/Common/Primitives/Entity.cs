namespace Domain.Common.Primitives;
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    protected Entity(TId id)
    {
        Id = id;
    }
    protected Entity()
    {
    }

    public TId? Id { get; protected init; }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return left is not null && right is not null && left.Equals(right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id!.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object ?)other);
    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode() * 41;
    }
}
