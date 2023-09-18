namespace Pokegraph.Api.DomainServices;

public class EvolutionChecker : IEvolutionChecker
{
    private readonly IPokemon _repository;

    public EvolutionChecker(IPokemon repository)
    {
        _repository = repository;
    }

    public async Task<bool> CanEvolveFromTo(PokemonNumber fromNumber, PokemonNumber toNumber)
    {
        if (fromNumber == toNumber)        
            throw new DomainException("Pokemon can't evolve to the same number.");        

        var pokemonEvolution = await _repository.GetPokemonByNumber(toNumber)
            ?? throw new RecordNotFoundException($"Pokemon number {toNumber.Value} not found.");

        if (pokemonEvolution.EvolvesFrom != null && pokemonEvolution.EvolvesFrom.Count > 0)        
            throw new DomainException($"Pokemon {pokemonEvolution.Name} already has a pre-evolution.");        

        return true;
    }
}