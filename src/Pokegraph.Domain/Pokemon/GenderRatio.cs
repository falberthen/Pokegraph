namespace Pokegraph.Domain.Pokemon;

public class GenderRatio : ValueObject<GenderRatio>
{
    public decimal? MaleRatio { get; private set; }
    public decimal? FemaleRatio { get; private set; }

    public static GenderRatio From(decimal? maleRatio, decimal? femaleRatio)
    {
        maleRatio ??= 0;
        femaleRatio ??= 0;

        var total = maleRatio + femaleRatio;

        if (maleRatio < 0 || femaleRatio < 0)
            throw new DomainException("Invalid gender ratio.");
        
        if (total < 0 || total > 100)
            throw new DomainException("Invalid gender ratio.");

        if (maleRatio == 0)
            maleRatio = 100 - femaleRatio;

        if (femaleRatio == 0)
            femaleRatio = 100 - maleRatio;

        return new GenderRatio(maleRatio, femaleRatio);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        if (MaleRatio != null) yield return MaleRatio;
        if (FemaleRatio != null) yield return FemaleRatio;
    }

    protected GenderRatio() { }

    private GenderRatio(decimal? maleRatio, decimal? femaleRatio)
    {
        MaleRatio = maleRatio;
        FemaleRatio = femaleRatio;
    }
}
