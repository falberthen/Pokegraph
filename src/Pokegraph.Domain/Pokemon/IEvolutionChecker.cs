namespace Pokegraph.Domain.Pokemon;

public interface IEvolutionChecker
{
    Task<bool> CanEvolveFromTo(PokemonNumber fromNumber, PokemonNumber toNumber);
}