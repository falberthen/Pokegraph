namespace Pokegraph.Domain.Pokemon;

public class PhysicalAttributes : ValueObject<PhysicalAttributes>
{
    public decimal Height { get; private set; }
    public decimal Weigth { get; private set; }

    public static PhysicalAttributes From(decimal height, decimal weight)
    {
        if (height <= 0)
            throw new DomainException("Invalid height.");
        if (weight <= 0)
            throw new DomainException("Invalid weight.");

        return new PhysicalAttributes(height, weight);
    }

    protected PhysicalAttributes() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Height;
        yield return Weigth;
    }

    private PhysicalAttributes(decimal height, decimal weight)
    {
        Height = height;
        Weigth = weight;
    }
}
