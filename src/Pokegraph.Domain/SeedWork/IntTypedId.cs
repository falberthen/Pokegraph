namespace Pokegraph.Domain.SeedWork;

public abstract class IntTypedId : ValueObject<IntTypedId>
{
    public int Value { get; }

    public IntTypedId(int value)
    {
        if(value <= 0) 
            throw new DomainException("Value must be greater than zero.");

        Value = value;
    }

    public override int GetHashCode()
    {
        return EqualityComparer<int>.Default.GetHashCode(Value);
    }

    public static bool operator ==(IntTypedId? left, IntTypedId? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(IntTypedId? left, IntTypedId? right)
    {
        return !Equals(left, right);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}