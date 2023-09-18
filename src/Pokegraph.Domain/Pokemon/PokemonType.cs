namespace Pokegraph.Domain.Pokemon;

public class PokemonType : ValueObject<PokemonType>
{
    public string Name { get; set; }

    public static PokemonType From(string typeName)
    {
        if (string.IsNullOrWhiteSpace(typeName))
            throw new DomainException("Pokemon's type cannot be null or whitespace.");

        var pokemonType = new PokemonType(typeName);
       
        if (!_supportedTypes.Contains(pokemonType))
            throw new DomainException($"Pokemon's [{typeName}] type is not supported.");

        return pokemonType;
    }

    public static PokemonType Grass => new("Grass");
    public static PokemonType Fire => new("Fire");
    public static PokemonType Water => new("Water");
    public static PokemonType Bug => new("Bug");
    public static PokemonType Normal => new("Normal");
    public static PokemonType Poison => new("Poison");
    public static PokemonType Electric => new("Electric");
    public static PokemonType Ground => new("Ground");
    public static PokemonType Psychic => new("Psychic");
    public static PokemonType Fighting => new("Fighting");
    public static PokemonType Rock => new("Rock");
    public static PokemonType Ghost => new("Ghost");
    public static PokemonType Ice => new("Ice");
    public static PokemonType Dragon => new("Dragon");

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }

    protected PokemonType() { }

    private static IEnumerable<PokemonType> _supportedTypes
    {
        get
        {
            yield return Grass;
            yield return Fire;
            yield return Water;
            yield return Bug;
            yield return Normal;
            yield return Poison;
            yield return Electric;
            yield return Ground;
            yield return Psychic;
            yield return Fighting;
            yield return Rock;
            yield return Ghost;
            yield return Ice;
            yield return Dragon;
        }
    }

    private PokemonType(string typeName)
    {
        Name = typeName;
    }
}
