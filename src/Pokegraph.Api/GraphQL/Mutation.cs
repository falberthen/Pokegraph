namespace Pokegraph.Api.GraphQL;

public class Mutation
{
    private readonly IMapper _mapper;
    
    public Mutation(IMapper mapper) => _mapper = mapper;
    
    public async Task<PokemonViewModel> InsertPokemon(
        PokemonData inputData, [Service] IEvolutionChecker evolutionChecker,
        [Service] IPokemon pokemonRepository, [Service] ITopicEventSender eventSender)
    {
        // Checks if you're assigning evolution to a cataloged Pokémon
        if (inputData.EvolvesToNumber is not null)
        {
            await evolutionChecker.CanEvolveFromTo(
                PokemonNumber.From(inputData.Number), 
                PokemonNumber.From(inputData.EvolvesToNumber!.Value)
            );
        }            

        var pokemon = Pokemon.CatalogNew(inputData);

        await pokemonRepository
            .InsertPokemon(pokemon);

        var viewModel = _mapper.Map<PokemonViewModel>(pokemon);

        await eventSender
            .SendAsync(nameof(InsertPokemon), viewModel);

        return viewModel;
    }

    public async Task<PokemonViewModel> UpdatePokemon(
        PokemonData inputData, [Service] IEvolutionChecker evolutionChecker,
        [Service] IPokemon pokemonRepository, [Service] ITopicEventSender eventSender)
    { 
        var pokemon = await pokemonRepository
            .GetPokemonByNumber(PokemonNumber.From(inputData.Number))
            ?? throw new ArgumentNullException($"Pokemon number {inputData.Number} not found");

        // Checks if you're assigning evolution to a cataloged Pokémon
        if (inputData.EvolvesToNumber is not null) { 
            await evolutionChecker.CanEvolveFromTo(
                PokemonNumber.From(inputData.Number), 
                PokemonNumber.From(inputData.EvolvesToNumber!.Value)
            );
        }

        pokemon.SetAttributes(inputData);

        await pokemonRepository
            .UpdatePokemon(pokemon);
        
        var viewModel = _mapper.Map<PokemonViewModel>(pokemon);

        await eventSender
            .SendAsync(nameof(UpdatePokemon), viewModel);

        return viewModel;
    }
}