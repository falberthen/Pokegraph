namespace Pokegraph.Api.GraphQL;

public class Subscription
{
    [Subscribe]
    [Topic(nameof(Query.ListPokemon))]
    public int OnListedPokemon([EventMessage] int pokemonListCount) =>
        pokemonListCount;

    [Subscribe]
    [Topic(nameof(Mutation.InsertPokemon))]
    public PokemonViewModel OnInsertedPokemon([EventMessage] PokemonViewModel insertedPokemon) =>
        insertedPokemon;

    [Subscribe]
    [Topic(nameof(Mutation.UpdatePokemon))]
    public PokemonViewModel OnUpdatedPokemon([EventMessage] PokemonViewModel updatedPokemon) =>
        updatedPokemon;
}