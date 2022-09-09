namespace EventService.Domain.Contracts;

public class IdValueBase : IEquatable<IdValueBase>
{
    public Guid Value { get; }

    protected IdValueBase(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidOperationException("Id value cannot be empty!");
        }

        Value = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is not null && obj is IdValueBase other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public bool Equals(IdValueBase? other)
    {
        return Value == other?.Value;
    }

    public static bool operator ==(IdValueBase obj1, IdValueBase obj2)
    {
        return object.Equals(obj1, null) ? object.Equals(obj2, null) : obj1.Equals(obj2);
    }

    public static bool operator !=(IdValueBase x, IdValueBase y)
    {
        return !(x == y);
    }
}
