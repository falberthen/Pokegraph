namespace Pokegraph.Domain.Pokemon;

public class Pokemon : AggregateRoot<PokemonNumber>
{
    public string Name { get; private set; }
    public decimal? CatchRate { get; private set; }
    public bool IsLegendary { get; private set; }
    public string? Avatar { get; private set; }
    public PhysicalAttributes? PhysicalAttributes { get; private set; }
    public GenderRatio? GenderRatio { get; private set; }
    public PokemonType PrimaryType { get; private set; }
    public PokemonType? SecondaryType { get; private set; }
    public BaseStats BaseStats { get; private set; }
    public PokemonNumber? EvolvesToNumber { get; private set; }

    public virtual Pokemon? EvolvesTo { get; }
    public virtual IReadOnlyCollection<Pokemon>? EvolvesFrom { get; }

    public static Pokemon CatalogNew(PokemonData data)
    {
        return new Pokemon(data);
    }

    public void SetAttributes(PokemonData data)
    {
        EnsureValidState(data);

        Number = PokemonNumber.From(data.Number);
        Name = data.Name;
        CatchRate = data.CatchRate;
        IsLegendary = data.IsLegendary;
        Avatar = data.Avatar;
        PhysicalAttributes = PhysicalAttributes.From(data.Height, data.Weigth);
        GenderRatio = GenderRatio.From(data.MaleRatio, data.FemaleRatio);
        PrimaryType = PokemonType.From(data.PrimaryType);
        BaseStats = BaseStats.From(data);

        if (data.EvolvesToNumber.HasValue)
            EvolvesToNumber = PokemonNumber.From(data.EvolvesToNumber.Value);

        if (data.SecondaryType is not null)
            SecondaryType = PokemonType.From(data.SecondaryType);
    }

    private void EnsureValidState(PokemonData data)
    {
        if (data is null)
            throw new DomainException(nameof(data));

        if (data.Number <= 0)
            throw new DomainException("Pokemon's number must be valid.");

        if (string.IsNullOrWhiteSpace(data.Name))
            throw new DomainException("Pokemon's name cannot be null or whitespace.");
    }

    private Pokemon(PokemonData data) => SetAttributes(data);

    private Pokemon() {}
}