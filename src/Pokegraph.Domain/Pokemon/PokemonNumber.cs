namespace Pokegraph.Domain.Pokemon;

public sealed class PokemonNumber : IntTypedId
{
    public static PokemonNumber From(int value)
    {
        return new PokemonNumber(value);
    }

    private PokemonNumber(int value) : base(value) {}
}