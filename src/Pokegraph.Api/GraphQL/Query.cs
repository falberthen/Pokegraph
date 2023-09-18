namespace Pokegraph.Api.GraphQL;

public class Query
{
    private readonly IMapper _mapper;

    public Query(IMapper mapper) => _mapper = mapper;

    public async Task<IEnumerable<PokemonViewModel>> ListPokemon(
        [Service]IPokemon pokemonRepository, [Service]ITopicEventSender eventSender)
    {
        var pokemonList = await pokemonRepository
            .ListPokemon();

        await eventSender
            .SendAsync(nameof(ListPokemon), pokemonList.Count());

        return pokemonList
            .Select(p => _mapper.Map<PokemonViewModel>(p));
    }

    public async Task<PokemonViewModel> GetPokemonByNumber(int number, 
        [Service]IPokemon pokemonRepository)
    {
       var pokemon = await pokemonRepository
            .GetPokemonByNumber(PokemonNumber.From(number))
            ?? throw new RecordNotFoundException($"Pokemon number {number} not found.");

        return _mapper.Map<PokemonViewModel>(pokemon);
    }
}