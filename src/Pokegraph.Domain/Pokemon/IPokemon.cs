namespace Pokegraph.Domain.Pokemon;

public interface IPokemon
{
    Task<IEnumerable<Pokemon>> ListPokemon();
    Task<Pokemon> GetPokemonByNumber(PokemonNumber number);
    Task InsertPokemon(Pokemon pokemon);
    Task UpdatePokemon(Pokemon pokemon);
}